using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Nessos.LinqOptimizer.Base;
using Nessos.LinqOptimizer.CSharp;
using LambdaMicrobenchmarking;

namespace benchmarks
{
    class ClashOfLambdas
    {
        static void Main(string[] args)
        {
            //////////////////////////
            // Input initialization //
            //////////////////////////
            var N = 10000000;
            var v = Enumerable.Range(1, N).Select(x => (long)x % 1000).ToArray();
            var vHi = Enumerable.Range(1, 100000).Select(x => (long)x).ToArray();
            var vLow = Enumerable.Range(1, 100).Select(x => (long)x).ToArray();

            ///////////////////////////
            // Benchmarks definition //
            ///////////////////////////
            Func<long> sumBaseline = () =>
            {
                var acc = 0L;
                for (int i = 0; i < v.Length; i++)
                    acc += v[i];
                return acc;
            };
            Func<long> sumOfSquaresBaseline = () =>
            {
                var acc = 0L;
                for (int i = 0; i < v.Length; i++)
                    acc += v[i] * v[i];
                return acc;
            };
            Func<long> sumOfSquaresEvenBaseline = () =>
            {
                var acc = 0L;
                for (int i = 0; i < v.Length; i++)
                    if (v[i] % 2 == 0)
                        acc += v[i] * v[i];
                return acc;
            };
            Func<long> cartBaseline = () =>
            {
                var acc = 0L;
                for (int d = 0; d < vHi.Length; d++)
                    for (int dp = 0; dp < vLow.Length; dp++)
                        acc += vHi[d] * vLow[dp];
                return acc;
            };
            Func<long> sumLinq = () => v.Sum();
            Func<long> sumLinqOpt = v.AsQueryExpr().Sum().Compile();
            Func<long> sumSqLinq = () => v.Select(x => x * x).Sum();
            Func<long> sumSqLinqOpt = v.AsQueryExpr().Select(x => x * x).Sum().Compile();
            Func<long> sumSqEvensLinq = () => v.Where(x => x % 2 == 0).Select(x => x * x).Sum();
            Func<long> sumSqEvenLinqOpt = v.AsQueryExpr().Where(x => x % 2 == 0).Select(x => x * x).Sum().Compile();
            Func<long> cartLinq = () => (from x in vHi
                                         from y in vLow
                                         select x * y).Sum();
            Func<long> cartLinqOpt = (from x in vHi.AsQueryExpr()
                                      from y in vLow
                                      select x * y).Sum().Compile();
            Func<long> parSumLinq = () => v.AsParallel().Sum();
            Func<long> parSumLinqOpt = v.AsParallelQueryExpr().Sum().Compile();
            Func<long> parSumSqLinq = () => v.AsParallel().Select(x => x * x).Sum();
            Func<long> parSumSqLinqOpt = v.AsParallelQueryExpr().Select(x => x * x).Sum().Compile();
            Func<long> parSumSqEvensLinq = () => v.AsParallel().Where(x => x % 2 == 0).Select(x => x * x).Sum();
            Func<long> parSumSqEvenLinqOpt = v.AsParallelQueryExpr().Where(x => x % 2 == 0).Select(x => x * x).Sum().Compile();
            Func<long> parCartLinq = () => (from x in vHi.AsParallel()
                                            from y in vLow
                                            select x * y).Sum();
            Func<long> parCartLinqOpt = (from x in vHi.AsParallelQueryExpr()
                                         from y in vLow
                                         select x * y).Sum().Compile();

            //////////////////////////
            // Benchmarks execution //
            //////////////////////////
            Script<long>.Of(new Tuple<String, Func<long>>[] {           
                Tuple.Create("sumBaseline", sumBaseline),
                Tuple.Create("sumSeq", sumLinq),
                Tuple.Create("sumSeqOpt", sumLinqOpt),
                Tuple.Create("sumPar", parSumLinq),
                Tuple.Create("sumParOpt", parSumLinqOpt),
                Tuple.Create("sumOfSquaresBaseline", sumOfSquaresBaseline),
                Tuple.Create("sumOfSquaresSeq", sumSqLinq),
                Tuple.Create("sumOfSquaresSeqOpt", sumSqLinqOpt),
                Tuple.Create("sumOfSquaresPar", parSumSqLinq),
                Tuple.Create("sumOfSquaresParOpt", parSumSqLinqOpt),
                Tuple.Create("sumOfSquaresEvenBaseline",sumOfSquaresEvenBaseline),
                Tuple.Create("sumOfSquaresEvenSeq", sumSqEvensLinq),
                Tuple.Create("sumOfSquaresEvenSeqOpt", sumSqEvenLinqOpt),
                Tuple.Create("sumOfSquaresEvenPar",  parSumSqEvensLinq),
                Tuple.Create("sumOfSquaresEvenParOpt",  parSumSqEvenLinqOpt),
                Tuple.Create("cartBaseline", cartBaseline),
                Tuple.Create("cartSeq", cartLinq),
                Tuple.Create("cartSeqOpt",cartLinqOpt),
                Tuple.Create("cartPar", parCartLinq),
                Tuple.Create("cartParOpt", parCartLinqOpt)})
            .RunAll();
        }

        #region TO-BE-REMOVED
        /* static int Iterations = 10;

        static double[] measurements = new double[Iterations];

        static T Consume<T>(T dummy)
        {
            return dummy;
        }

        static int getN()
        {
            return Iterations;
        }

        static double getMean()
        {
            if (getN() > 0)
            {
                return getSum() / getN();
            }
            else
            {
                return Double.NaN;
            }
        }

        static double getSum()
        {
            if (getN() > 0)
            {
                double s = 0;
                for (int i = 0; i < getN(); i++)
                {
                    s += measurements[i];
                }
                return s;
            }
            else
            {
                return Double.NaN;
            }
        }

        static double getStandardDeviation()
        {
            return Math.Sqrt(getVariance());
        }

        static public double getVariance()
        {
            if (getN() > 0)
            {
                double v = 0;
                double m = getMean();
                for (int i = 0; i < Iterations; i++)
                {
                    v += Math.Pow(measurements[i] - m, 2);
                }
                return v / (getN() - 1);
            }
            else
            {
                return Double.NaN;
            }
        }

        static double getMeanErrorAt(double confidence)
        {
            if (getN() <= 2) return Double.NaN;
            var distribution = new StudentT(0, 1, getN() - 1);
            double a = distribution.InverseCumulativeDistribution(1 - (1 - confidence) / 2);
            return a * getStandardDeviation() / Math.Sqrt(getN());
        }

        static void Measure<T>(string title, Func<T> action)
        {
            Array.Clear(measurements, 0, getN());

            //Force Full GC prior to execution
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            double st = 0.0, sst = 0.0;

            var sw = new Stopwatch();

            // First invocation to compile method.
            Consume(action());

            for (int i = 0; i < getN(); i++)
            {
                sw.Restart();

                //Avoid dead-code.
                Consume(action());

                sw.Stop();

                measurements[i] = sw.ElapsedMilliseconds;
            }

            //Add-Up invocation stats
            foreach (double m in measurements)
            {
                st += m;
                sst += Math.Pow(m, 2);
            }

            double mean = st / (double)Iterations;
            double sdev = Math.Sqrt(sst / (double)Iterations - Math.Pow(mean, 2));

            Console.WriteLine("Math-{0,-25}\t{1,10} {2,10:0.00} {3,4:0.00} {4}", title, getMean(), getMeanErrorAt(0.999), getStandardDeviation(), "ms/op");
            Console.WriteLine("Mine-{0,-25}\t{1,10} {2,10:0.00} {3,4:0.00} {4}", title, mean, Double.NaN, sdev, "ms/op");
        } */
        #endregion
    }
}
