Clash of the Lambdas
====================
Microbenchmarking collection functional APIs of Java 8, Scala, C#, F# on Windows and Linux.

* Java 8 (jvm / [jmh](http://openjdk.java.net/projects/code-tools/jmh/))
  * sequential
  * parallel
* Scala (jvm / [jmh](http://openjdk.java.net/projects/code-tools/jmh/))
  * sequential
  * parallel
  * optimized sequential/parallel with [Scala-Blitz](http://scala-blitz.github.io/)
* C# (mono / (custom iterative measure))
  * sequential
  * parallel
  * optimized sequential/parallel with [LinqOptimizer](https://github.com/nessos/LinqOptimizer)
* F# (mono / (custom iterative measure))
  * sequential
  * parallel
  * optimized sequential/parallel with [LinqOptimizer](https://github.com/nessos/LinqOptimizer)

Setting up on Windows
--------------------
* Install [JDK8](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html) and create the ```JAVA_HOME``` env variable (for maven to work)
* Install [Gnu Make for Windows](http://gnuwin32.sourceforge.net/packages/make.htm) and put the ```bin``` directory to ```PATH```
* Extract [Maven](http://maven.apache.org/download.cgi) and put the ```bin``` directory to ```PATH```
* Install the C#, F# compilers (if you have Visual Studio 2013 you already have them)
* Update the paths in ```Makefile```
<!-- * The java/scala microbenchmark suites run via ```jmh```. The ```scala``` archetype was still [under-test](http://mail.openjdk.java.net/pipermail/jmh-dev/2014-March/000556.html) from the jmh team, so until the final version makes it up to the repositories we have to generate the archetype ourselves. -->
<!--    * ```hg clone http://hg.openjdk.java.net/code-tools/jmh/ jmh``` -->
<!--    * ```cd jmh/``` -->
<!--    * ```mvn clean install archetype:update-local-catalog -DskipTests``` -->

Setting up on Ubuntu
--------------------
* Install/Extract [JDK8](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html) and update PATH
* ```sudo apt-get install make```
* ```sudo apt-get install maven```
* Follow the [instructions](http://fsharp.org/use/linux/) on [fsharp.org](http://fsharp.org)
<!-- * The java/scala microbenchmark suites run via ```jmh```. The ```scala``` archetype was still [under-test](http://mail.openjdk.java.net/pipermail/jmh-dev/2014-March/000556.html) from the jmh team, so until the final version makes it up to the repositories we have to generate the archetype ourselves. -->
<!--    * ```hg clone http://hg.openjdk.java.net/code-tools/jmh/ jmh``` -->
<!--    * ```cd jmh/``` -->
<!--    * ```mvn clean install archetype:update-local-catalog -DskipTests``` -->

Running the microbenchmarks
---------------------------
* Compile all tests with ```make```
* Clean with ```make clean```
* Compile a specific suite with ```make {java, csharp, fsharp, scala}```
* Run microbenchmarks with ```make bench-{java, csharp, fsharp, scala}``` each
  time to get a fresh compilation followed by a run (e.g., ```make
  bench-java```).
