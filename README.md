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
* Install [JDK8](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html). Create the ```JAVA_HOME``` env variable (for maven to work) and add to ```Path``` the ```JAVA_HOME\bin``` director
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
* Compile all tests with ```make```
* Clean with ```make clean```
* Compile a specific suite with ```make {java, csharp, fsharp, scala}```
* Run microbenchmarks with ```make bench-{java, csharp, fsharp, scala}``` (e.g., ```make
  bench-java```).
