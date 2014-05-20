LANGS = csharp java scala fsharp
BENCH := $(LANGS:%=bench-%) 

####################
# General Settings #
####################
JVM = java -Xms769m -Xmx769m -XX:-TieredCompilation #-XX:+UnlockDiagnosticVMOptions -XX:+LogCompilation

#########
# Paths #
#########

java_SRC 	= java
scala_SRC	= scala
fsharp_SRC 	= fsharp
csharp_SRC 	= csharp

csharp_OUT 	= $(GEN)/csharp
java_OUT 	= $(GEN)/java
fsharp_OUT 	= $(GEN)/fsharp
scala_OUT 	= $(GEN)/scala

GEN = build

########################
# OS specific commands #
########################
UNAME := $(shell uname)

ifeq ($(UNAME), Linux)
MONO = mono
csharp_COMPILE = mcs /optimize+ /checked- /out:$(csharp_OUT)/ClashOfLambdas.exe  \
	/r:$(csharp_SRC)/lib/LinqOptimizer.CSharp.dll \
	/r:$(csharp_SRC)/lib/LinqOptimizer.Base.dll \
	/r:$(csharp_SRC)/lib/LinqOptimizer.Core.dll \
	$(csharp_SRC)/ClashOfLambdas.cs
fsharp_COMPILE = fsharpc --optimize+ --checked- -r $(fsharp_SRC)/lib/LinqOptimizer.Base.dll  --nologo -r \
	$(fsharp_SRC)/lib/LinqOptimizer.Core.dll -r \
	$(fsharp_SRC)/lib/LinqOptimizer.FSharp.dll \
	--out:$(fsharp_OUT)/ClashOfLambdas.exe $(fsharp_SRC)/ClashOfLambdas.fs
endif
ifeq ($(UNAME), MINGW32_NT-6.2)
fsharp_COMPILE = C:\"Program\ Files\ \(x86\)"\"Microsoft\ SDKs"\F\#\\3.1\\Framework\\v4.0\\fsc.exe --optimize+ --checked- --nologo -r \
	$(fsharp_SRC)/lib/LinqOptimizer.Base.dll -r \
	$(fsharp_SRC)/lib/LinqOptimizer.Core.dll -r	\
	$(fsharp_SRC)/lib/LinqOptimizer.FSharp.dll \
	--out:$(fsharp_OUT)/ClashOfLambdas.exe $(fsharp_SRC)/ClashOfLambdas.fs
csharp_COMPILE = csc /out:$(csharp_OUT)/ClashOfLambdas.exe -nologo /optimize+ /checked- \
	/r:$(csharp_SRC)/lib/LinqOptimizer.CSharp.dll \
	/r:$(csharp_SRC)/lib/LinqOptimizer.Base.dll \
	/r:$(csharp_SRC)/lib/LinqOptimizer.Core.dll \
	$(csharp_SRC)\ClashOfLambdas.cs
endif

##################################
# Commands to run the benchmarks #
##################################

jmh_ARGS	= -gc true -f 1 -i 10 -wi 10 -tu ms ".*"
java_RUN 	= $(JVM) -jar $(java_OUT)/microbenchmarks.jar $(jmh_ARGS)
scala_RUN	= $(JVM) -jar $(scala_OUT)/microbenchmarks.jar $(jmh_ARGS)
csharp_RUN 	= $(MONO) $(csharp_OUT)/ClashOfLambdas.exe
fsharp_RUN 	= $(MONO) $(fsharp_OUT)/ClashOfLambdas.exe

#####################
# Compilation Rules #
#####################

all: $(LANGS)

csharp : 
	@echo "Compiling C#"
	@mkdir -p $(csharp_OUT)
	$(csharp_COMPILE)
	@cp $(csharp_SRC)/lib/*.dll $(csharp_OUT)/.

fsharp : 
	@echo "Compiling F#"
	@mkdir -p $(fsharp_OUT)
	$(fsharp_COMPILE)
	@cp $(fsharp_SRC)/lib/*.dll $(fsharp_OUT)/.	
	@cp $(fsharp_SRC)/lib/*.config $(fsharp_OUT)/.

java : 	
	@echo "Compiling Java"
	@mkdir -p $(java_OUT)	
	@mvn -q -f $(java_SRC)/pom.xml clean install
	@cp $(java_SRC)/target/microbenchmarks.jar $(java_OUT)

scala : 
	@echo "Compiling Scala"
	@mkdir -p $(scala_OUT)
	@mvn -q -f $(scala_SRC)/pom.xml clean install
	@cp $(scala_SRC)/target/microbenchmarks.jar $(scala_OUT)

########################
# Run Benchmarks Rules #
########################

$(BENCH): bench-% : %
	@echo "Benchmarking $* version:"
	$($*_RUN)

.PHONY: $(LANGS) $(BENCH) clean

clean:
	rm -rf $(GEN)/
