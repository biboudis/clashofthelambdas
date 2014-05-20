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
    var v : Array[Long] = _
    var vHi : Array[Long] = _
    var vLo : Array[Long] = _

    @Setup
    def prepare() : Unit = {
      N = 10000000
      v = (0 until N).map(i => i.toLong % 1000).toArray
      vLo = (0 until 10000).map(i => i.toLong).toArray
      vHi = (0 until 1000).map(i => i.toLong).toArray
    }

    @GenerateMicroBenchmark
    def sumBaseline () : Long = {
      var i=0
      var sum=0L
      while (i < v.length) {
        sum += v(i)
        i += 1
      }
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresBaseline () : Long = {
      var i=0
      var sum=0L
      while (i < v.length) {
        sum += v(i) *  v(i)
        i += 1
      }
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresEvenBaseline () : Long = {
      var i=0
      var sum=0L
      while (i < v.length) {
	       if (v(i) % 2 == 0)
          sum += v(i) * v(i)
        i += 1
      }
      sum
    }

    @GenerateMicroBenchmark
    def cartBaseline () : Long = {
      var d, dp=0
      var sum=0L
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
    def sumSeq () : Long = {
      val sum : Long = v
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def sumPar () : Long = {
      val sum : Long = v
	.par
	.view
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresSeq () : Long = {
      val sum : Long = v
      .view
      .map(d => d * d)
      .sum
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresPar () : Long = {
      val sum : Long = v
	.par
	.view
	.map(d => d * d)
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def cartSeq () : Long = {
      val sum : Long = vHi
	.view
	.flatMap(d => vLo.view.map (dp => dp * d))
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def cartPar () : Long = {
      val sum : Long = vHi
	.par
	.view
	.flatMap(d => vLo.view.map (dp => dp * d))
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresEvenSeq () : Long = {
      val res : Long = v
	.filter(x => x % 2 == 0)
	.map(x => x * x)
	.sum
      res
    }

    @GenerateMicroBenchmark
    def sumOfSquaresEvenPar () : Long = {
      val res : Long = v
	.par
	.view
	.filter(x => x % 2 == 0)
	.map(x => x * x)
	.sum
      res
    }

    @GenerateMicroBenchmark
    def sumSeqBlitz () : Long = {
      optimize {
	val sum : Long = v
	  .sum
	sum
      }
    }

    @GenerateMicroBenchmark
    def sumOfSquaresSeqBlitz () : Long = {
      optimize {
	val sum : Long = v
	  .map(d => d * d)
	  .sum
	sum
      }
    }

    @GenerateMicroBenchmark
    def cartSeqBlitz () : Long = {
      optimize {
	val sum : Long = vHi
	  .flatMap(d => vLo.view.map (dp => dp * d))
	  .sum
	sum
      }
    }

    @GenerateMicroBenchmark
    def sumOfSquaresEvenSeqBlitz () : Long = {
      optimize {
	val res : Long = v
	  .filter(x => x % 2 == 0)
	  .map(x => x * x)
	  .sum
	res
      }
    }

    @GenerateMicroBenchmark
    def sumParBlitz () : Long = {
      import scala.collection.par._
      import Scheduler.Implicits.global

      val sum : Long = v
	.toPar
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresParBlitz () : Long = {
      import scala.collection.par._
      import Scheduler.Implicits.global

      val sum : Long = v
	.toPar
	.map(d => d * d)
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def cartParBlitz () : Long = {
      import scala.collection.par._
      import Scheduler.Implicits.global

      val sum : Long = vHi
	.toPar
	.flatMap(d => vLo.map (dp => dp * d))
	.sum
      sum
    }

    @GenerateMicroBenchmark
    def sumOfSquaresEvenParBlitz () : Long = {
      import scala.collection.par._
      import Scheduler.Implicits.global
      import scala.reflect.ClassTag // https://github.com/scala-blitz/scala-blitz/issues/34

      val res : Long = v
	.toPar
	.filter(x => x % 2 == 0)
	.map(x => x * x)
	.sum
	res
    }
  }
}
