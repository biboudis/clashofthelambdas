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

Scala
------

C#
--

F#
--
