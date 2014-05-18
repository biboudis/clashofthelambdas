package benchmarks;

import java.util.stream.*;
import org.openjdk.jmh.annotations.*;
import java.util.concurrent.TimeUnit;
import java.util.*;

@OutputTimeUnit(TimeUnit.NANOSECONDS)
@BenchmarkMode(Mode.AverageTime)
@State(Scope.Thread)
public class ClashOfLambdas {

    public static final int N = 10000000;
    
    static double[] v, valuesLo, valuesHi;

    static {
        v = IntStream.range(0, N).mapToDouble(i -> i).toArray();
        valuesHi = IntStream.range(0, 10000).mapToDouble(i -> i).toArray();
        valuesLo = IntStream.range(0, 1000).mapToDouble(i -> i).toArray();
    }

    @GenerateMicroBenchmark
    public double sumBaseline() {
        double acc = 0;
	for (int i =0 ; i < v.length ; i++) {
	    acc += v[i];
	}
	return acc;
    }
       
    @GenerateMicroBenchmark
    public double sumOfSquaresBaseline() {
        double acc = 0;
	for (int i =0 ; i < v.length ; i++) {
	    acc += v[i] * v[i];
	}
	return acc;
    }

    @GenerateMicroBenchmark
    public double cartBaseline() {
	double cart = 0;
	for (int d = 0 ; d < valuesHi.length ; d++) {
	    for (int dp = 0 ; dp < valuesLo.length ; dp++){
		cart += valuesHi[d] * valuesLo[dp];
	    }
	}
        return cart;
    }

    @GenerateMicroBenchmark
    public double sumOfSquaresEvenBaseline() {
        double acc = 0;
	for (int i =0 ; i < v.length ; i++) {
	    if (v[i] % 2 == 0)
		acc += v[i] * v[i];
	}
	return acc;
    }
    
    @GenerateMicroBenchmark
    public double sumSeq() {
        double sum
                = DoubleStream.of(v)
                .sum();
        return sum;
    }

    @GenerateMicroBenchmark
    public double sumPar() {
        double sum
                = DoubleStream.of(v)
                .parallel()
                .sum();
        
        return sum;
    }
       
    @GenerateMicroBenchmark
    public double sumOfSquaresSeq() {
        double sum
                = DoubleStream.of(v)
                .map(d -> d * d)
                .sum();
        return sum;
    }
        
    @GenerateMicroBenchmark
    public double sumOfSquaresPar() {
        double sum
                = DoubleStream.of(v)
                .parallel()
                .map(d -> d * d)
                .sum();
        return sum;
    }

    @GenerateMicroBenchmark
    public double cartSeq() {
        double cart
                = DoubleStream.of(valuesHi)
                .flatMap(d -> DoubleStream.of(valuesLo).map(dP -> dP * d))
                .sum();       
        return cart;
    }
        
    @GenerateMicroBenchmark
    public double cartPar() {
        double cart
                = DoubleStream.of(valuesHi)
                .parallel()
                .flatMap(d -> DoubleStream.of(valuesLo).map(dP -> dP * d))
                .sum();
        
        return cart;
    }
    
    @GenerateMicroBenchmark
    public double sumOfSquaresEvenSeq() {
        double sum = DoubleStream.of(v)
	    .filter(x -> x % 2 == 0)
	    .map(x -> x * x)
	    .sum();

        return sum;
    }

    @GenerateMicroBenchmark
    public double sumOfSquaresEvenPar() {
        double sum = DoubleStream.of(v)
	    .parallel()
	    .filter(x -> x % 2 == 0)
	    .map(x -> x * x)
	    .sum();
       
        return sum;
    }

    // example ported from https://msmvps.com/blogs/jon_skeet/archive/2007/10/03/linq-to-silliness-generating-a-mandelbrot-with-parallel-potential.aspx
    static int MaxIterations = 1000;
    static double SampleWidth = 3.2;
    static double SampleHeight = 2.5;
    static double OffsetX = -2.1;
    static double OffsetY = -1.25;
    static int ImageWidth = 900;
    static int ImageHeight = (int) (SampleHeight * ImageWidth / SampleWidth);
    static double[] rowPoints, columnPoints;

    static {
        rowPoints = IntStream.range(0, ImageHeight).mapToDouble(i -> i).toArray();
        columnPoints = IntStream.range(0, ImageWidth).mapToDouble(i -> i).toArray();
    }

    static int ComputeMandelbrotIndex(double row, double col) {
        double x = (col * SampleWidth) / ImageWidth + OffsetX;
        double y = (row * SampleHeight) / ImageHeight + OffsetY;

        double y0 = y;
        double x0 = x;

        for (int i = 0; i < MaxIterations; i++) {
            if (x * x + y * y >= 4) {
                return (byte) ((i % 255) + 1);
            }
            double xtemp = x * x - y * y + x0;
            y = 2 * x * y + y0;
            x = xtemp;
        }
        return 0;
    }

    // @GenerateMicroBenchmark
    public double[] mandelbrotSeq() {
        double[] data
                = DoubleStream.of(rowPoints)
                .flatMap(rowPoint -> DoubleStream.of(columnPoints)
                                    .map(columnPoint -> ComputeMandelbrotIndex(rowPoint, columnPoint)))
                .toArray();
        return data;
    }

    
    // @GenerateMicroBenchmark
    public double[] mandelbrotPar() {
        double[] data
                = DoubleStream.of(rowPoints)
                .parallel()
                .flatMap(rowPoint -> DoubleStream.of(columnPoints)
                                    .map(columnPoint -> ComputeMandelbrotIndex(rowPoint, columnPoint)))
                .toArray();
        
        return data;
    }
}
