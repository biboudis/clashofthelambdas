Clash of the Lambdas
====================
Microbenchmarking collection, functional APIs of the VM multiparadigm languages
Java 8, Scala, C#, F# on Windows and on Linux.

The results are discussed in our ICOOOLPS'14 workshop paper: 

> http://arxiv.org/abs/1406.6631

To run the benchmarking suite as is, you will need a system with approximately
769mb of free space for heap allocation. Regarding execution time, a run on a
single platform takes approximately 30-40 minutes on an Intel Core i5.

* Java 8 (jvm / [jmh](http://openjdk.java.net/projects/code-tools/jmh/))
  * sequential
  * parallel
* Scala (jvm / [jmh](http://openjdk.java.net/projects/code-tools/jmh/))
  * sequential
  * parallel
  * optimized sequential/parallel with [ScalaBlitz](http://scala-blitz.github.io/)
* C# (clr & mono / [Lambda Microbenchmarking](https://github.com/biboudis/LambdaMicrobenchmarking)<sup>1</sup>)
  * sequential
  * parallel
  * optimized sequential/parallel with [LinqOptimizer](https://github.com/nessos/LinqOptimizer)
* F# (clr & mono / [Lambda Microbenchmarking](https://github.com/biboudis/LambdaMicrobenchmarking)<sup>1</sup>)
  * sequential
  * parallel
  * optimized sequential/parallel with [LinqOptimizer](https://github.com/nessos/LinqOptimizer)

Setting up on Windows
--------------------
* Install [JDK8](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html). Create the ```JAVA_HOME``` env variable (for maven to work) and add to ```Path``` the ```JAVA_HOME\bin``` directory
* Install [Gnu Make for Windows](http://gnuwin32.sourceforge.net/packages/make.htm) and put the ```bin``` directory to ```PATH```
* Extract [Maven](http://maven.apache.org/download.cgi) and put the ```bin``` directory to ```PATH```
* Install the C#, F# compilers (if you have Visual Studio 2013 you already have them)
* Update the paths in ```Makefile```

Setting up on Ubuntu
--------------------
* Install/Extract [JDK8](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html) and update PATH
* ```sudo apt-get install make```
* ```sudo apt-get install maven```
* Follow the [instructions](http://fsharp.org/use/linux/) on [fsharp.org](http://fsharp.org)

Running the microbenchmarks 
---------------------------
(via a console on Linux o via a Powershell console on Windows)

* Compile all tests with ```make```
* Clean with ```make clean```
* Compile a specific suite with ```make {java, csharp, fsharp, scala}```
* Run microbenchmarks with ```make bench-{java, csharp, fsharp, scala}``` (e.g., ```make
  bench-java```).

Processing the results
----------------------
If you want to process the unified results we offer a gawk script for linux (that also makes use
of the dos2unix command to convert windows result file encoding).

* Run the benchmark suite with on both windows and linux with ```make bench >
  results.{windows, linux}``` (any filename), or use it with tee to view the results as it runs with ```make bench | tee results.{windows, linux}```
* See the unified results for all languages, platforms and benchmarks (the comma
  separated values are benchmark, mean, mean error, sdev) by running
  ```./process results.linux results.windows > results.processed``` (make
  the script executable first).

Team
----
[@biboudis](https://twitter.com/biboudis), [@NickPalladinos](https://twitter.com/NickPalladinos) and [Y. Smaragdakis](http://cgi.di.uoa.gr/~smaragd/)

**Footnotes:**

1. A small utility that was factored out as a seperate project.
