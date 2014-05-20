Windows 8.1
===========
Java
----
b.ClashOfLambdas.cartBaseline                 avgt        10        4.513        0.097    ms/op
b.ClashOfLambdas.cartPar                      avgt        10        2.599        0.035    ms/op
b.ClashOfLambdas.cartSeq                      avgt        10        5.100        0.111    ms/op
b.ClashOfLambdas.sumBaseline                  avgt        10        9.843        0.374    ms/op
b.ClashOfLambdas.sumOfSquaresBaseline         avgt        10        9.854        0.137    ms/op
b.ClashOfLambdas.sumOfSquaresEvenBaseline     avgt        10       13.787        0.270    ms/op
b.ClashOfLambdas.sumOfSquaresEvenPar          avgt        10       12.078        0.303    ms/op
b.ClashOfLambdas.sumOfSquaresEvenSeq          avgt        10       19.591        0.518    ms/op
b.ClashOfLambdas.sumOfSquaresPar              avgt        10        8.631        0.254    ms/op
b.ClashOfLambdas.sumOfSquaresSeq              avgt        10        9.961        0.265    ms/op
b.ClashOfLambdas.sumPar                       avgt        10        8.724        0.314    ms/op
b.ClashOfLambdas.sumSeq                       avgt        10        9.766        0.157    ms/op
Scala
------
b.ClashOfLambdas.cartBaseline                 avgt        10        4.638        0.123    ms/op
b.ClashOfLambdas.cartPar                      avgt        10     4533.947      101.561    ms/op
b.ClashOfLambdas.cartParBlitz                 avgt        10      299.876        7.704    ms/op
b.ClashOfLambdas.cartSeq                      avgt        10      185.640        5.241    ms/op
b.ClashOfLambdas.cartSeqBlitz                 avgt        10      214.329        3.362    ms/op
b.ClashOfLambdas.sumBaseline                  avgt        10        9.570        0.116    ms/op
b.ClashOfLambdas.sumOfSquaresBaseline         avgt        10        9.765        0.254    ms/op
b.ClashOfLambdas.sumOfSquaresEvenBaseline     avgt        10       14.835        2.416    ms/op
b.ClashOfLambdas.sumOfSquaresEvenPar          avgt        10     8959.370      389.941    ms/op
b.ClashOfLambdas.sumOfSquaresEvenParBlitz     avgt        10       77.581        2.047    ms/op
b.ClashOfLambdas.sumOfSquaresEvenSeq          avgt        10      373.515       13.061    ms/op
b.ClashOfLambdas.sumOfSquaresEvenSeqBlitz     avgt        10       84.716        1.499    ms/op
b.ClashOfLambdas.sumOfSquaresPar              avgt        10     1299.274       54.593    ms/op
b.ClashOfLambdas.sumOfSquaresParBlitz         avgt        10       43.734        0.898    ms/op
b.ClashOfLambdas.sumOfSquaresSeq              avgt        10      178.808        4.727    ms/op
b.ClashOfLambdas.sumOfSquaresSeqBlitz         avgt        10       45.269        0.539    ms/op
b.ClashOfLambdas.sumPar                       avgt        10     1196.716       27.620    ms/op
b.ClashOfLambdas.sumParBlitz                  avgt        10        8.617        0.209    ms/op
b.ClashOfLambdas.sumSeq                       avgt        10      118.541        3.770    ms/op
b.ClashOfLambdas.sumSeqBlitz                  avgt        10        9.738        0.164    ms/op

C#
--
sumBaseline                           12.3 ms/op +/- 2.1
sumSeq                                  69 ms/op +/- 1.9
sumSeqOpt                             12.8 ms/op +/- 3.4
sumPar                                28.6 ms/op +/- 8.94
sumParOpt                                9 ms/op +/- 2.83
sumOfSquaresBaseline                  10.4 ms/op +/- 3.26
sumOfSquaresSeq                      100.2 ms/op +/- 5.93
sumOfSquaresSeqOpt                    15.2 ms/op +/- 3.09
sumOfSquaresPar                       61.6 ms/op +/- 4.8
sumOfSquaresParOpt                     8.8 ms/op +/- 2.56
sumOfSquaresEvenBaseline              14.2 ms/op +/- 2.96
sumOfSquaresEvenSeq                   86.4 ms/op +/- 5.16
sumOfSquaresEvenSeqOpt                58.6 ms/op +/- 4.39
sumOfSquaresEvenPar                   56.7 ms/op +/- 5.33
sumOfSquaresEvenParOpt                10.9 ms/op +/- 2.62
cartBaseline                           6.9 ms/op +/- .83
cartSeq                              178.2 ms/op +/- 14.19
cartSeqOpt                            11.7 ms/op +/- 2.83
cartPar                               75.9 ms/op +/- 11.98
cartParOpt                             6.4 ms/op +/- .66

F#
--
sumBaseline                             10 ms/op +/- 4.07
sumSeq                                61.6 ms/op +/- 20.58
sumSeqOpt                             13.9 ms/op +/- 5.97
sumPar                                21.2 ms/op +/- 7.12
sumParOpt                              8.2 ms/op +/- 4.12
sumOfSquaresBaseline                   9.4 ms/op +/- 4.08
sumOfSquaresSeq                      166.7 ms/op +/- 55.79
sumOfSquaresSeqOpt                    12.7 ms/op +/- 5.12
sumOfSquaresPar                       56.3 ms/op +/- 20.28
sumOfSquaresParOpt                     8.4 ms/op +/- 3.77
sumOfSquaresEvenBaseline              11.9 ms/op +/- 4.95
sumOfSquaresEvenSeq                  202.4 ms/op +/- 67.86
sumOfSquaresEvenSeqOpt                54.4 ms/op +/- 18.98
sumOfSquaresEvenPar                   51.3 ms/op +/- 19.28
sumOfSquaresEvenParOpt                10.8 ms/op +/- 5.11
cartBaseline                           6.3 ms/op +/- 2.24
cartSeq                              284.8 ms/op +/- 95.74
cartSeqOpt                            10.5 ms/op +/- 3.53
cartPar                                 62 ms/op +/- 21.28
cartParOpt                             5.8 ms/op +/- 2.09

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
