import scala.util.Random
import scala.collection.optimizer._

package benchmarks {

  import org.openjdk.jmh.annotations.GenerateMicroBenchmark
  import org.openjdk.jmh.annotations.Scope
  import org.openjdk.jmh.annotations.Setup
  import org.openjdk.jmh.annotations.State
  import org.openjdk.jmh.annotations.BenchmarkMode
  import org.openjdk.jmh.annotations.Mode
  import org.openjdk.jmh.annotations.OutputTimeUnit

  import java.util.concurrent.TimeUnit

  @OutputTimeUnit(TimeUnit.NANOSECONDS)
  @BenchmarkMode(Array(Mode.AverageTime))
  @State(Scope.Thread)
  class ClashOfLambdas {

    var N : Int = _
    var v : Array[Double] = _
    var vHi : Array[Double] = _
    var vLo : Array[Double] = _

    @Setup
    def prepare() : Unit = {
      N = 10000000
      v = (0 until N).map(i => i.toDouble).toArray
      vLo = (0 until 10000).map(i => i.toDouble).toArray
      vHi = (0 until 1000).map(i => i.toDouble).toArray
    }

    @GenerateMicroBenchmark
    def sumBaseline () : Double = {
      var i=0
      var sum=0.0
      while (i < v.length) {
        sum += v(i)
        i += 1
      }
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresBaseline () : Double = {
      var i=0
      var sum=0.0
      while (i < v.length) {
        sum += v(i) *  v(i)
        i += 1
      }
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresEvenBaseline () : Double = {
      var i=0
      var sum=0.0
      while (i < v.length) {
	       if (v(i) % 2 == 0)
          sum += v(i) * v(i)
        i += 1
      }
      sum
    }

    @GenerateMicroBenchmark
    def cartBaseline () : Double = {
      var d, dp=0
      var sum=0.0
      while (d < vHi.length) {
	dp = 0
	while (dp < vLo.length) {
          sum += vHi(d) * vLo(dp)
	  dp +=1 
	}
        d += 1
      }
      sum
    }

    @GenerateMicroBenchmark
    def sumSeq () : Double = {
      val sum : Double = v
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def sumPar () : Double = {
      val sum : Double = v
	.par
	.view
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresSeq () : Double = {
      val sum : Double = v
      .view
      .map(d => d * d)
      .sum
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresPar () : Double = {
      val sum : Double = v
	.par
	.view
	.map(d => d * d)
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def cartSeq () : Double = {
      val sum : Double = vHi
	.view
	.flatMap(d => vLo.view.map (dp => dp * d))
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def cartPar () : Double = {
      val sum : Double = vHi
	.par
	.view
	.flatMap(d => vLo.view.map (dp => dp * d))
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresEvenSeq () : Double = {
      val res : Double = v
	.filter(x => x % 2 == 0)
	.map(x => x * x)
	.sum
      res
    }

    @GenerateMicroBenchmark
    def sumOfSquaresEvenPar () : Double = {
      val res : Double = v
	.par
	.view
	.filter(x => x % 2 == 0)
	.map(x => x * x)
	.sum
      res
    }

    @GenerateMicroBenchmark
    def sumSeqBlitz () : Double = {
      optimize {
	val sum : Double = v
	  .sum
	sum
      }
    }

    @GenerateMicroBenchmark
    def sumOfSquaresSeqBlitz () : Double = {
      optimize {
	val sum : Double = v
	  .map(d => d * d)
	  .sum
	sum
      }
    }

    @GenerateMicroBenchmark
    def cartSeqBlitz () : Double = {
      optimize {
	val sum : Double = vHi
	  .flatMap(d => vLo.view.map (dp => dp * d))
	  .sum
	sum
      }
    }

    @GenerateMicroBenchmark
    def sumOfSquaresEvenSeqBlitz () : Double = {
      optimize {
	val res : Double = v
	  .filter(x => x % 2 == 0)
	  .map(x => x * x)
	  .sum
	res
      }
    }

    @GenerateMicroBenchmark
    def sumParBlitz () : Double = {
      import scala.collection.par._
      import Scheduler.Implicits.global

      val sum : Double = v
	.toPar
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresParBlitz () : Double = {
      import scala.collection.par._
      import Scheduler.Implicits.global

      val sum : Double = v
	.toPar
	.map(d => d * d)
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def cartParBlitz () : Double = {
      import scala.collection.par._
      import Scheduler.Implicits.global

      val sum : Double = vHi
	.toPar
	.flatMap(d => vLo.map (dp => dp * d))
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresEvenParBlitz () : Double = {
      import scala.collection.par._
      import Scheduler.Implicits.global
      import scala.reflect.ClassTag // https://github.com/scala-blitz/scala-blitz/issues/34

      val res : Double = v
	.toPar
	.filter(x => x % 2 == 0)
	.map(x => x * x)
	.sum
	res
    }
  }
}
