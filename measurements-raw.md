Windows 8.1
===========
Java
----
Benchmark                                     Mode   Samples         Mean   Mean error    Units
b.ClashOfLambdas.cartBaseline                 avgt        10        4.237        0.036    ms/op
b.ClashOfLambdas.cartPar                      avgt        10        2.368        0.045    ms/op
b.ClashOfLambdas.cartSeq                      avgt        10        4.779        0.047    ms/op
b.ClashOfLambdas.sumBaseline                  avgt        10        6.960        0.020    ms/op
b.ClashOfLambdas.sumOfSquaresBaseline         avgt        10        7.074        0.046    ms/op
b.ClashOfLambdas.sumOfSquaresEvenBaseline     avgt        10       10.598        0.205    ms/op
b.ClashOfLambdas.sumOfSquaresEvenPar          avgt        10       10.326        0.118    ms/op
b.ClashOfLambdas.sumOfSquaresEvenSeq          avgt        10       16.832        0.149    ms/op
b.ClashOfLambdas.sumOfSquaresPar              avgt        10        6.804        0.016    ms/op
b.ClashOfLambdas.sumOfSquaresSeq              avgt        10        7.113        0.015    ms/op
b.ClashOfLambdas.sumPar                       avgt        10        6.785        0.018    ms/op
b.ClashOfLambdas.sumSeq                       avgt        10        6.982        0.015    ms/op

Scala
------
Benchmark                                     Mode   Samples         Mean   Mean error    Units
b.ClashOfLambdas.cartBaseline                 avgt        10        4,342        0,031    ms/op
b.ClashOfLambdas.cartPar                      avgt        10     4135,784       64,031    ms/op
b.ClashOfLambdas.cartParBlitz                 avgt        10      247,326        6,953    ms/op
b.ClashOfLambdas.cartSeq                      avgt        10      139,159        2,626    ms/op
b.ClashOfLambdas.cartSeqBlitz                 avgt        10      167,944        0,985    ms/op
b.ClashOfLambdas.sumBaseline                  avgt        10        6,883        0,017    ms/op
b.ClashOfLambdas.sumOfSquaresBaseline         avgt        10        7,012        0,020    ms/op
b.ClashOfLambdas.sumOfSquaresEvenBaseline     avgt        10       10,387        0,064    ms/op
b.ClashOfLambdas.sumOfSquaresEvenPar          avgt        10     8302,784      387,512    ms/op
b.ClashOfLambdas.sumOfSquaresEvenParBlitz     avgt        10       62,283        0,030    ms/op
b.ClashOfLambdas.sumOfSquaresEvenSeq          avgt        10      283,203       12,459    ms/op
b.ClashOfLambdas.sumOfSquaresEvenSeqBlitz     avgt        10       67,252        1,669    ms/op
b.ClashOfLambdas.sumOfSquaresPar              avgt        10     1734,704       27,898    ms/op
b.ClashOfLambdas.sumOfSquaresParBlitz         avgt        10       35,686        0,062    ms/op
b.ClashOfLambdas.sumOfSquaresSeq              avgt        10      135,205        0,447    ms/op
b.ClashOfLambdas.sumOfSquaresSeqBlitz         avgt        10       35,799        0,056    ms/op
b.ClashOfLambdas.sumPar                       avgt        10     1570,726       12,356    ms/op
b.ClashOfLambdas.sumParBlitz                  avgt        10        6,739        0,044    ms/op
b.ClashOfLambdas.sumSeq                       avgt        10       90,711        0,568    ms/op
b.ClashOfLambdas.sumSeqBlitz                  avgt        10        6,939        0,015    ms/op

C#
--
Benchmark                             Mean Mean-Error   Sdev  Unit
sumBaseline                              7       0,00   0,00 ms/op
sumSeq                                68,3       7,97   5,27 ms/op
sumSeqOpt                              8,9       0,48   0,32 ms/op
sumPar                                22,6       1,06   0,70 ms/op
sumParOpt                              6,1       0,48   0,32 ms/op
sumOfSquaresBaseline                     7       0,00   0,00 ms/op
sumOfSquaresSeq                       99,6       6,81   4,50 ms/op
sumOfSquaresSeqOpt                    12,3       1,75   1,16 ms/op
sumOfSquaresPar                       58,1       0,48   0,32 ms/op
sumOfSquaresParOpt                     6,1       0,48   0,32 ms/op
sumOfSquaresEvenBaseline              11,1       0,48   0,32 ms/op
sumOfSquaresEvenSeq                   82,2       2,34   1,55 ms/op
sumOfSquaresEvenSeqOpt                52,7       1,43   0,95 ms/op
sumOfSquaresEvenPar                     55       9,54   6,31 ms/op
sumOfSquaresEvenParOpt                 8,1       0,48   0,32 ms/op
cartBaseline                             6       0,00   0,00 ms/op
cartSeq                              169,5       6,70   4,43 ms/op
cartSeqOpt                            11,3       0,73   0,48 ms/op
cartPar                               69,8      10,66   7,05 ms/op
cartParOpt                               6       0,00   0,00 ms/op

F#
--
Benchmark                             Mean Mean-Error   Sdev  Unit
sumBaseline                            7,8       1,19   0,79 ms/op
sumSeq                                  63       0,00   0,00 ms/op
sumSeqOpt                              8,9       0,48   0,32 ms/op
sumPar                                22,8       1,56   1,03 ms/op
sumParOpt                              6,1       0,48   0,32 ms/op
sumOfSquaresBaseline                   7,1       0,48   0,32 ms/op
sumOfSquaresSeq                      176,6       1,91   1,26 ms/op
sumOfSquaresSeqOpt                    11,4       0,78   0,52 ms/op
sumOfSquaresPar                       56,7       6,09   4,03 ms/op
sumOfSquaresParOpt                     6,3       1,02   0,67 ms/op
sumOfSquaresEvenBaseline              10,7       0,73   0,48 ms/op
sumOfSquaresEvenSeq                  201,8       4,50   2,97 ms/op
sumOfSquaresEvenSeqOpt                52,1       0,48   0,32 ms/op
sumOfSquaresEvenPar                   47,2       0,64   0,42 ms/op
sumOfSquaresEvenParOpt                 8,5       1,92   1,27 ms/op
cartBaseline                             6       0,00   0,00 ms/op
cartSeq                              280,3       3,64   2,41 ms/op
cartSeqOpt                            11,2       0,96   0,63 ms/op
cartPar                               62,4       3,28   2,17 ms/op
cartParOpt                               6       0,00   0,00 ms/op

Linux
=====
Java
----
Benchmark                                     Mode   Samples         Mean   Mean error    Units
b.ClashOfLambdas.cartBaseline                 avgt        10        4.699        0.084    ms/op
b.ClashOfLambdas.cartPar                      avgt        10        3.215        0.042    ms/op
b.ClashOfLambdas.cartSeq                      avgt        10        5.593        0.116    ms/op
b.ClashOfLambdas.sumBaseline                  avgt        10       13.117        0.158    ms/op
b.ClashOfLambdas.sumOfSquaresBaseline         avgt        10       13.540        0.195    ms/op
b.ClashOfLambdas.sumOfSquaresEvenBaseline     avgt        10       19.224        0.446    ms/op
b.ClashOfLambdas.sumOfSquaresEvenPar          avgt        10       17.548        0.203    ms/op
b.ClashOfLambdas.sumOfSquaresEvenSeq          avgt        10       26.916        0.564    ms/op
b.ClashOfLambdas.sumOfSquaresPar              avgt        10       11.938        0.221    ms/op
b.ClashOfLambdas.sumOfSquaresSeq              avgt        10       13.548        0.503    ms/op
b.ClashOfLambdas.sumPar                       avgt        10       11.778        0.293    ms/op
b.ClashOfLambdas.sumSeq                       avgt        10       13.446        0.529    ms/op

Scala
------
Benchmark                                     Mode   Samples         Mean   Mean error    Units
b.ClashOfLambdas.cartBaseline                 avgt        10        4.667        0.113    ms/op
b.ClashOfLambdas.cartPar                      avgt        10     4065.581       65.469    ms/op
b.ClashOfLambdas.cartParBlitz                 avgt        10      388.181        4.301    ms/op
b.ClashOfLambdas.cartSeq                      avgt        10      252.805        3.582    ms/op
b.ClashOfLambdas.cartSeqBlitz                 avgt        10      311.149        5.949    ms/op
b.ClashOfLambdas.sumBaseline                  avgt        10       11.807        0.104    ms/op
b.ClashOfLambdas.sumOfSquaresBaseline         avgt        10       11.907        0.148    ms/op
b.ClashOfLambdas.sumOfSquaresEvenBaseline     avgt        10       16.472        0.316    ms/op
b.ClashOfLambdas.sumOfSquaresEvenPar          avgt        10     8292.391      420.132    ms/op
b.ClashOfLambdas.sumOfSquaresEvenParBlitz     avgt        10      127.203        5.710    ms/op
b.ClashOfLambdas.sumOfSquaresEvenSeq          avgt        10      580.509       11.480    ms/op
b.ClashOfLambdas.sumOfSquaresEvenSeqBlitz     avgt        10      136.363        2.950    ms/op
b.ClashOfLambdas.sumOfSquaresPar              avgt        10     1423.887       86.170    ms/op
b.ClashOfLambdas.sumOfSquaresParBlitz         avgt        10       72.547        0.966    ms/op
b.ClashOfLambdas.sumOfSquaresSeq              avgt        10      291.827        3.107    ms/op
b.ClashOfLambdas.sumOfSquaresSeqBlitz         avgt        10       89.058        1.742    ms/op
b.ClashOfLambdas.sumPar                       avgt        10     1346.200       66.932    ms/op
b.ClashOfLambdas.sumParBlitz                  avgt        10       12.217        0.357    ms/op
b.ClashOfLambdas.sumSeq                       avgt        10      187.238       13.277    ms/op
b.ClashOfLambdas.sumSeqBlitz                  avgt        10       14.496        0.312    ms/op

C#
--
Benchmark                 	      Mean Mean-Error   Sdev  Unit
sumBaseline              	      14.3       1.02   0.67 ms/op
sumSeq                   	     111.8       0.96   0.63 ms/op
sumSeqOpt                	      16.8       0.96   0.63 ms/op
sumPar                   	     427.3     105.74  69.94 ms/op
sumParOpt                	      12.2       3.40   2.25 ms/op
sumOfSquaresBaseline     	      20.1       2.07   1.37 ms/op
sumOfSquaresSeq          	     247.5       2.17   1.43 ms/op
sumOfSquaresSeqOpt       	      17.8       1.19   0.79 ms/op
sumOfSquaresPar          	       478      56.49  37.37 ms/op
sumOfSquaresParOpt       	      12.4       2.28   1.51 ms/op
sumOfSquaresEvenBaseline 	     110.9       3.06   2.02 ms/op
sumOfSquaresEvenSeq      	     301.2      12.84   8.50 ms/op
sumOfSquaresEvenSeqOpt   	     109.4       3.20   2.12 ms/op
sumOfSquaresEvenPar      	     495.9      71.74  47.45 ms/op
sumOfSquaresEvenParOpt   	        58       2.57   1.70 ms/op
cartBaseline             	        15       0.00   0.00 ms/op
cartSeq                  	     287.6       6.10   4.03 ms/op
cartSeqOpt               	      15.6       0.78   0.52 ms/op
cartPar                  	     286.8      24.85  16.44 ms/op
cartParOpt               	      10.5       2.05   1.35 ms/op

F#
--
Benchmark                 	      Mean Mean-Error   Sdev  Unit
sumBaseline              	        17       2.25   1.49 ms/op
sumSeq                   	     124.1       2.30   1.52 ms/op
sumSeqOpt                	      21.1       2.19   1.45 ms/op
sumPar                   	     437.1      85.99  56.88 ms/op
sumParOpt                	      13.2       2.23   1.48 ms/op
sumOfSquaresBaseline     	      25.2       3.62   2.39 ms/op
sumOfSquaresSeq          	     249.9       9.41   6.23 ms/op
sumOfSquaresSeqOpt       	      21.9       2.41   1.60 ms/op
sumOfSquaresPar          	     556.6      65.82  43.54 ms/op
sumOfSquaresParOpt       	      14.5       3.98   2.64 ms/op
sumOfSquaresEvenBaseline 	     114.8       3.48   2.30 ms/op
sumOfSquaresEvenSeq      	     399.1      32.42  21.44 ms/op
sumOfSquaresEvenSeqOpt   	     118.6       1.63   1.07 ms/op
sumOfSquaresEvenPar      	     564.5      46.87  31.00 ms/op
sumOfSquaresEvenParOpt   	        60       2.36   1.56 ms/op
cartBaseline             	      13.1       1.12   0.74 ms/op
cartSeq                  	     355.6       3.85   2.55 ms/op
cartSeqOpt               	      15.7       1.24   0.82 ms/op
cartPar                  	     385.9      21.11  13.96 ms/op
cartParOpt               	        10       1.75   1.15 ms/op
