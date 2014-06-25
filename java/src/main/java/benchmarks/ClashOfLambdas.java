package benchmarks;

import java.util.stream.*;
import org.openjdk.jmh.annotations.*;
import java.util.concurrent.TimeUnit;
import java.util.*;

@OutputTimeUnit(TimeUnit.NANOSECONDS)
@BenchmarkMode(Mode.AverageTime)
@State(Scope.Thread)
public class ClashOfLambdas {
    
    public static class Ref {
	public int num;

	public Ref(int num) {
	    this.num = num;
	}
    }
    
    public static final int N = 10000000;
    
    static long[] v, valuesLo, valuesHi;
    static ClashOfLambdas.Ref[] refs;

    static {
        v = IntStream.range(0, N).mapToLong(i -> i % 1000).toArray();
        valuesHi = IntStream.range(0, 1000000).mapToLong(i -> i).toArray();
        valuesLo = IntStream.range(0, 10).mapToLong(i -> i).toArray();
	refs = IntStream.range(0, N).mapToObj(n -> new ClashOfLambdas.Ref(n)).toArray(size -> new ClashOfLambdas.Ref[size]);
    }

    @GenerateMicroBenchmark
    public long sumBaseline() {
        long acc = 0;
	for (int i =0 ; i < v.length ; i++) {
	    acc += v[i];
	}
	return acc;
    }
       
    @GenerateMicroBenchmark
    public long sumOfSquaresBaseline() {
        long acc = 0;
	for (int i =0 ; i < v.length ; i++) {
	    acc += v[i] * v[i];
	}
	return acc;
    }

    @GenerateMicroBenchmark
    public long cartBaseline() {
	long cart = 0;
	for (int d = 0 ; d < valuesHi.length ; d++) {
	    for (int dp = 0 ; dp < valuesLo.length ; dp++){
		cart += valuesHi[d] * valuesLo[dp];
	    }
	}
        return cart;
    }

    @GenerateMicroBenchmark
    public long sumOfSquaresEvenBaseline() {
        long acc = 0;
	for (int i =0 ; i < v.length ; i++) {
	    if (v[i] % 2 == 0)
		acc += v[i] * v[i];
	}
	return acc;
    }
    
    @GenerateMicroBenchmark
    public long sumSeq() {
        long sum
                = LongStream.of(v)
                .sum();
        return sum;
    }

    @GenerateMicroBenchmark
    public long sumPar() {
        long sum
                = LongStream.of(v)
                .parallel()
                .sum();
        
        return sum;
    }
       
    @GenerateMicroBenchmark
    public long sumOfSquaresSeq() {
        long sum
                = LongStream.of(v)
                .map(d -> d * d)
                .sum();
        return sum;
    }
        
    @GenerateMicroBenchmark
    public long sumOfSquaresPar() {
        long sum
                = LongStream.of(v)
                .parallel()
                .map(d -> d * d)
                .sum();
        return sum;
    }

    @GenerateMicroBenchmark
    public long cartSeq() {
        long cart
                = LongStream.of(valuesHi)
                .flatMap(d -> LongStream.of(valuesLo).map(dP -> dP * d))
                .sum();       
        return cart;
    }
        
    @GenerateMicroBenchmark
    public long cartPar() {
        long cart
                = LongStream.of(valuesHi)
                .parallel()
                .flatMap(d -> LongStream.of(valuesLo).map(dP -> dP * d))
                .sum();
        
        return cart;
    }
    
    @GenerateMicroBenchmark
    public long sumOfSquaresEvenSeq() {
        long sum = LongStream.of(v)
	    .filter(x -> x % 2 == 0)
	    .map(x -> x * x)
	    .sum();

        return sum;
    }

    @GenerateMicroBenchmark
    public long sumOfSquaresEvenPar() {
        long sum = LongStream.of(v)
	    .parallel()
	    .filter(x -> x % 2 == 0)
	    .map(x -> x * x)
	    .sum();
       
        return sum;
    }

    @GenerateMicroBenchmark
    public long refSeq() {
	long length = Stream.of(refs)
	    .filter(box -> box.num % 5 == 0)
	    .filter(box -> box.num % 7 == 0)
	    .count();

	return length;
    }

    @GenerateMicroBenchmark
    public long refPar() {
	long length = Stream.of(refs)
	    .parallel()
	    .filter(box -> box.num % 5 == 0)
	    .filter(box -> box.num % 7 == 0)
	    .count();

	return length;
    }
}
