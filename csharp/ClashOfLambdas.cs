using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Nessos.LinqOptimizer.Base;
using Nessos.LinqOptimizer.CSharp;

namespace benchmarks
{
    class ClashOfLambdas
    {
        static int Iterations = 10;
        static void Main(string[] args)
        {

	    //////////////////////////
            // Input initialization //
            //////////////////////////
            var N = 10000000;
            var v = Enumerable.Range(1, N).Select(x => (double)x).ToArray();
            var vHi = Enumerable.Range(1, 10000).Select(x => (double)x).ToArray();
            var vLow = Enumerable.Range(1, 1000).Select(x => (double)x).ToArray();

	    ///////////////////////////
            // Benchmarks definition //
            ///////////////////////////
	    Func<double> sumBaseline = () => {
	      var acc = 0.0;
	      for (int i = 0; i < v.Length; i++)
		acc += v[i];
	      return acc;
	    };
	    Func<double> sumOfSquaresBaseline = () => {
	      var acc = 0.0;
	      for (int i = 0; i < v.Length; i++)
		acc += v[i]*v[i];
	      return acc;
	    };
	    Func<double> sumOfSquaresEvenBaseline = () => {
	      var acc = 0.0;
	      for (int i = 0; i < v.Length; i++)
		if (v[i] % 2 == 0)
		  acc += v[i]*v[i];
	      return acc;
	    };
	    Func<double> cartBaseline = () => {
	      var acc = 0.0;
	      for (int d = 0; d < vHi.Length; d++)
		for (int dp = 0; dp < vLow.Length; dp++)
		  acc += vHi[d] * vLow[dp];
	      return acc;
	    };
            Func<double> sumLinq = () => v.Sum();
            Func<double> sumLinqOpt = v.AsQueryExpr().Sum().Compile();
            Func<double> sumSqLinq = () => v.Select(x => x * x).Sum();
            Func<double> sumSqLinqOpt = v.AsQueryExpr().Select(x => x * x).Sum().Compile();
            Func<double> sumSqEvensLinq = () => v.Where(x => x % 2 == 0).Select(x => x * x).Sum();
            Func<double> sumSqEvenLinqOpt = v.AsQueryExpr().Where(x => x % 2 == 0).Select(x => x * x).Sum().Compile();
            Func<double> cartLinq = () => (from x in vHi
					   from y in vLow
					   select x * y).Sum();
            Func<double> cartLinqOpt = (from x in vHi.AsQueryExpr()
                                        from y in vLow
                                        select x * y).Sum().Compile();
            Func<double> parSumLinq = () => v.AsParallel().Sum();
            Func<double> parSumLinqOpt = v.AsParallelQueryExpr().Sum().Compile();
            Func<double> parSumSqLinq = () => v.AsParallel().Select(x => x * x).Sum();
            Func<double> parSumSqLinqOpt = v.AsParallelQueryExpr().Select(x => x * x).Sum().Compile();
            Func<double> parSumSqEvensLinq = () => v.AsParallel().Where(x => x % 2 == 0).Select(x => x * x).Sum();
            Func<double> parSumSqEvenLinqOpt = v.AsParallelQueryExpr().Where(x => x % 2 == 0).Select(x => x * x).Sum().Compile();
            Func<double> parCartLinq = () => (from x in vHi.AsParallel()
					      from y in vLow
					      select x * y).Sum();
            Func<double> parCartLinqOpt = (from x in vHi.AsParallelQueryExpr()
					   from y in vLow
					   select x * y).Sum().Compile();
	    
	    //////////////////////////
            // Benchmarks execution //
            //////////////////////////
            Measure("sumBaseline", () => sumBaseline());
            Measure("sumSeq", () => sumLinq());
	    Measure("sumSeqOpt", () => sumLinqOpt());
            Measure("sumPar", () => parSumLinq());
            Measure("sumParOpt", () => parSumLinqOpt());

            Measure("sumOfSquaresBaseline", () => sumOfSquaresBaseline());
            Measure("sumOfSquaresSeq", () => sumSqLinq());
            Measure("sumOfSquaresSeqOpt", () => sumSqLinqOpt());
            Measure("sumOfSquaresPar", () => parSumSqLinq());
            Measure("sumOfSquaresParOpt", () => parSumSqLinqOpt());

            Measure("sumOfSquaresEvenBaseline", () => sumOfSquaresEvenBaseline());
            Measure("sumOfSquaresEvenSeq", () => sumSqEvensLinq());
            Measure("sumOfSquaresEvenSeqOpt", () => sumSqEvenLinqOpt());
            Measure("sumOfSquaresEvenPar", () => parSumSqEvensLinq());
            Measure("sumOfSquaresEvenParOpt", () => parSumSqEvenLinqOpt());

            Measure("cartBaseline", () => cartBaseline());
            Measure("cartSeq", () => cartLinq());
            Measure("cartSeqOpt", () => cartLinqOpt());
            Measure("cartPar", () => parCartLinq());
            Measure("cartParOpt", () => parCartLinqOpt());
	    ////////////////////////////////////////////////////////////////////////////////////////////
            // Group-by test not used in Clash of The Lambdas					      //
	    // Reported and got fix thought: https://bugzilla.xamarin.com/show_bug.cgi?id=18673	      //
            ////////////////////////////////////////////////////////////////////////////////////////////
	    // var Ng = 1000000;
	    // var rnd = new Random();
	    // var g = Enumerable.Range(1, Ng).Select(x => rnd.Next(0, Ng / 2)).ToArray();
	    // Func<int[]> groupLinq = () => g.GroupBy(x => x)
	    //   .OrderBy(x => x.Key)
	    //   .Select(k => k.Count())
	    //   .ToArray();
	    // Func<int[]> groupLinqOpt = g.AsQueryExpr()
	    //   .GroupBy(x => x)
	    //   .OrderBy(x => x.Key)
	    //   .Select(k => k.Count())
	    //   .ToArray().Compile();
	    // Measure("groupSeq", () => groupLinq());
	    // Measure("groupSeqOpt", () => groupLinqOpt());
        }

        static void Measure<T>(string title, Func<T> action)
        {
            var sw = new Stopwatch();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
	    
            sw.Start();
            for (int i = 0; i < Iterations; i++)
            {
	      action();
            }
            sw.Stop();

            Console.WriteLine("{0,-25}\t{1,10} ms/op", title, sw.ElapsedMilliseconds / (float) Iterations);
        }
    }
}
