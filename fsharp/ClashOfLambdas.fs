open System
open System.Linq
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open Nessos.LinqOptimizer.FSharp
open Nessos.LinqOptimizer.Base

let Iterations = 10
let measuref<'T>(title, action : unit -> 'T) =
  let measurements = Array.create Iterations 0.0

  let sw = new Stopwatch()

  GC.Collect()
  GC.WaitForPendingFinalizers()
  GC.Collect()

  let mutable st = 0.0
  let mutable sst = 0.0

  action() |> ignore

  for i = 1 to Iterations-1 do
    sw.Restart()
    
    action() |> ignore

    sw.Stop()

    measurements.[i] <- (float sw.ElapsedMilliseconds)
    ()

  for m in measurements do
    st <- st + m
    sst <- sst + Math.Pow(m, 2.0)

  let mean = st / (float Iterations)
  let sdev = Math.Sqrt(sst / (float Iterations) - Math.Pow(mean, 2.0))
    
  Console.WriteLine("{0,-25}\t{1,10} ms/op +/- {2:#.##}", title, mean, sdev);

[<EntryPoint>]
let main argv =
  //////////////////////////
  // Input initialization //
  //////////////////////////
  let N = 10000000
  let v = Enumerable.Range(1, N).Select(fun x -> (int64) x).ToArray()
  let vHi = Enumerable.Range(1, 10000).Select(fun x -> (int64) x).ToArray()
  let vLow = Enumerable.Range(1, 1000).Select(fun x -> (int64) x).ToArray()

  ///////////////////////////
  // Benchmarks definition //
  ///////////////////////////
  let sumBaseline () =
    let mutable acc = 0L
    for i=0 to v.Length-1 do
      acc <- v.[i] + acc
    acc

  let sumofSquaresBaseline () =
    let mutable acc = 0L
    for i=0 to v.Length-1 do
      acc <- v.[i] * v.[i] + acc
    acc

  let sumofSquaresEvenBaseline () =
    let mutable acc = 0L
    for i=0 to v.Length-1 do
      if v.[i] % 2L = 0L
      then
        acc <- v.[i] * v.[i] + acc
    acc

  let cartBaseline () =
    let mutable acc = 0L
    for d=0 to vHi.Length-1 do
      for dp=0 to vLow.Length-1 do
        acc <- vHi.[d] * vHi.[dp] + acc
    acc

  let sumLinq () = Seq.sum v
  let sumLinqOpt = v |> Query.ofSeq |> Query.sum |> Query.compile
  let sumSqLinq () = v |> Seq.map (fun x -> x * x) |> Seq.sum
  let sumSqLinqOpt = v |> Query.ofSeq |> Query.map(fun x -> x * x) |> Query.sum |> Query.compile
  let sumSqEvenLinq () = v |> Seq.filter (fun x -> x % 2L = 0L) |> Seq.map (fun x -> x * x) |> Seq.sum
  let sumSqEvenLinqOpt = v |> Query.ofSeq |> Query.filter (fun x -> x % 2L = 0L) |> Query.map(fun x -> x * x) |> Query.sum |> Query.compile
  let cartLinq () = vHi |> Seq.collect (fun x -> Seq.map (fun y -> x * y) vLow) |> Seq.sum
  let cartLinqOpt = vHi |> Query.ofSeq |> Query.collect (fun x -> Seq.map (fun y -> x * y) vLow) |> Query.sum |> Query.compile
  let parallelSumLinq() = v.AsParallel().Sum()
  let parallelSumLinqOpt= v |> PQuery.ofSeq |> PQuery.sum |> PQuery.compile
  let parallelSumSqLinq() = v.AsParallel().Select(fun x -> x * x).Sum()
  let parallelSumSqLinqOpt = v |> PQuery.ofSeq |> PQuery.map(fun x -> x * x) |> PQuery.sum |> PQuery.compile
  let parallelSumSqEvenLinq () = v.AsParallel().Where(fun x -> x % 2L = 0L).Select(fun x -> x * x).Sum()
  let parallelSumSqEvenLinqOpt = v |> PQuery.ofSeq |> PQuery.filter (fun x -> x % 2L = 0L) |> PQuery.map(fun x -> x * x) |> PQuery.sum |> PQuery.compile
  let parallelCartLinq () = vHi.AsParallel().SelectMany(fun x -> vLow.Select(fun y -> x * y)).Sum()
  let parallelCartLinqOpt = vHi |> PQuery.ofSeq |> PQuery.collect (fun x -> Seq.map (fun y -> x * y) vLow) |> PQuery.sum |> PQuery.compile

  //////////////////////////
  // Benchmarks execution //
  //////////////////////////
  measuref("sumBaseline", (fun () -> sumBaseline()))
  measuref("sumSeq", (fun () -> sumLinq()))
  measuref("sumSeqOpt", (fun () -> sumLinqOpt()))
  measuref("sumPar", (fun () -> parallelSumLinq ()))
  measuref("sumParOpt", (fun () -> parallelSumLinqOpt ()))

  measuref("sumOfSquaresBaseline", (fun () -> sumofSquaresBaseline()))
  measuref("sumOfSquaresSeq", (fun () -> sumSqLinq ()))
  measuref("sumOfSquaresSeqOpt", (fun () -> sumSqLinqOpt ()))
  measuref("sumOfSquaresPar", (fun () -> parallelSumSqLinq ()))
  measuref("sumOfSquaresParOpt", (fun () -> parallelSumSqLinqOpt ()))
  
  measuref("sumOfSquaresEvenBaseline", (fun () -> sumofSquaresEvenBaseline()))
  measuref("sumOfSquaresEvenSeq", (fun () -> sumSqEvenLinq ()))
  measuref("sumOfSquaresEvenSeqOpt", (fun () -> sumSqEvenLinqOpt ()))
  measuref("sumOfSquaresEvenPar", (fun () -> parallelSumSqEvenLinq ()))
  measuref("sumOfSquaresEvenParOpt", (fun () -> parallelSumSqEvenLinqOpt ()))
    
  measuref("cartBaseline", (fun () -> cartBaseline()))
  measuref("cartSeq", (fun () -> cartLinq()))
  measuref("cartSeqOpt", (fun () -> cartLinqOpt()))
  measuref("cartPar", (fun () -> parallelCartLinq()))
  measuref("cartParOpt", (fun () -> parallelCartLinqOpt()))

  0 
