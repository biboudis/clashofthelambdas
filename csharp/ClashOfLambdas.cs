using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Nessos.LinqOptimizer.Base;
using Nessos.LinqOptimizer.CSharp;
using MathNet.Numerics.Distributions;

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
      var v = Enumerable.Range(1, N).Select(x => (long) x % 1000).ToArray();
      var vHi = Enumerable.Range(1, 10000).Select(x => (long)x).ToArray();
      var vLow = Enumerable.Range(1, 1000).Select(x => (long)x).ToArray();

      ///////////////////////////
      // Benchmarks definition //
      ///////////////////////////
      Func<long> sumBaseline = () => {
	var acc = 0L;
	for (int i = 0; i < v.Length; i++)
	  acc += v[i];
	return acc;
      };
      Func<long> sumOfSquaresBaseline = () => {
	var acc = 0L;
	for (int i = 0; i < v.Length; i++)
	  acc += v[i]*v[i];
	return acc;
      };
      Func<long> sumOfSquaresEvenBaseline = () => {
	var acc = 0L;
	for (int i = 0; i < v.Length; i++)
	  if (v[i] % 2 == 0)
	    acc += v[i]*v[i];
	return acc;
      };
      Func<long> cartBaseline = () => {
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
      Console.WriteLine("{0,-25} \t{1,10} {2,6:0.00} {3,4:0.00} {4}", "Benchmark", "Mean", "Mean Error", "Sdev", "Units");

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
      // Group-by test not used in Clash of The Lambdas due to mono bug		              //
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

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Inspired by JMH															        //
    // http://hg.openjdk.java.net/code-tools/jmh/file/75f8b23444f6/jmh-core/src/main/java/org/openjdk/jmh/util/internal/AbstractStatistics.java //
    // http://hg.openjdk.java.net/code-tools/jmh/file/75f8b23444f6/jmh-core/src/main/java/org/openjdk/jmh/util/internal/ListStatistics.java     //
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
    static int Iterations = 10;

    static double[] measurements = new double[Iterations];

    static T Consume<T>(T dummy) 
    {
      return dummy;
    }

    static int getN()
    {
      return Iterations;
    }

    static double getMean() {
      if (getN() > 0) {
	return getSum() / getN();
      } else {
	return Double.NaN;
      }
    }

    static double getSum() 
    {
      if (getN() > 0) {
	double s = 0;
	for (int i = 0; i < getN(); i++) {
	  s += measurements[i];
	}
	return s;
      } else {
	return Double.NaN;
      }
    }

    static double getStandardDeviation()
    {
      return Math.Sqrt(getVariance());
    }

    static public double getVariance() 
    {
      if (getN() > 0) {
	double v = 0;
	double m = getMean();
	for (int i = 0; i < Iterations; i++) {
	  v += Math.Pow(measurements[i] - m, 2);
	}
	return v / (getN() - 1);
      } else {
	return Double.NaN;
      }
    }

    static double getMeanErrorAt(double confidence) 
    {
      if (getN() <= 2) return Double.NaN;
      var distribution = new StudentT(0, 1, getN()-1);
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

      for (int i = 0; i < getN(); i++) {
	sw.Restart();
	      
	//Avoid dead-code.
	Consume(action());

	sw.Stop();

	measurements[i]= sw.ElapsedMilliseconds;
      }

      //Add-Up invocation stats
      foreach(double m in measurements) {
	st += m;
	sst += Math.Pow(m, 2);
      }
	    
      double mean = st / (double) Iterations;
      double sdev = Math.Sqrt(sst/(double) Iterations - Math.Pow(mean, 2));

      Console.WriteLine("Math-{0,-25}\t{1,10} {2,10:0.00} {3,4:0.00} {4}", title, getMean(), getMeanErrorAt(0.999), getStandardDeviation(), "ms/op");
      Console.WriteLine("Mine-{0,-25}\t{1,10} {2,10:0.00} {3,4:0.00} {4}", title, mean, Double.NaN, sdev, "ms/op");
    }
  }
}
