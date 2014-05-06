Windows 8.1
===========
Java 8 (b132), x64, 4 Cores, 2.8 GHz, 2.5 GB mem -- no optimization flags
-------------------------------------------------------------------------
Java
-----
Benchmark                    Mode   Samples         Mean   Mean error    Units
cartBaseline                 avgt        10        9.065        0.135    ms/op
cartPar                      avgt        10       39.889        0.993    ms/op
cartSeq                      avgt        10       43.990        0.757    ms/op
sumBaseline                  avgt        10       11.544        0.549    ms/op
sumOfSquaresBaseline         avgt        10       11.629        0.487    ms/op
sumOfSquaresEvenBaseline     avgt        10      229.760        5.594    ms/op
sumOfSquaresEvenPar          avgt        10      100.417        2.866    ms/op
sumOfSquaresEvenSeq          avgt        10      262.315        4.361    ms/op
sumOfSquaresPar              avgt        10       36.953        0.439    ms/op
sumOfSquaresSeq              avgt        10       46.589        1.382    ms/op
sumPar                       avgt        10       23.390        0.469    ms/op
sumSeq                       avgt        10       45.093        1.310    ms/op

Scala
------
cartBaseline                 avgt        10        9.005        0.176    ms/op
cartPar                      avgt        10     3803.224     1035.157    ms/op
cartParBlitz                 avgt        10      264.186       16.924    ms/op
cartSeq                      avgt        10      281.839       11.319    ms/op
cartSeqBlitz                 avgt        10      208.580      110.957    ms/op
sumBaseline                  avgt        10       11.619        0.322    ms/op
sumOfSquarePar               avgt        10     1158.307       37.956    ms/op
sumOfSquareParBlitz          avgt        10       51.479        1.502    ms/op
sumOfSquareSeq               avgt        10       81.225        3.339    ms/op
sumOfSquareSeqBlitz          avgt        10       55.796        2.120    ms/op
sumOfSquaresBaseline         avgt        10       11.699        0.192    ms/op
sumOfSquaresEvenBaseline     avgt        10      228.633        3.699    ms/op
sumOfSquaresEvenPar          avgt        10     5210.339     3684.498    ms/op
sumOfSquaresEvenParBlitz     avgt        10      150.673       10.040    ms/op
sumOfSquaresEvenSeq          avgt        10      550.499      101.082    ms/op
sumOfSquaresEvenSeqBlitz     avgt        10      533.577       12.728    ms/op
sumPar                       avgt        10     1131.707       29.642    ms/op
sumParBlitz                  avgt        10        8.619        0.269    ms/op
sumSeq                       avgt        10       68.909        1.852    ms/op
sumSeqBlitz                  avgt        10       11.477        0.183    ms/op

C#
--
sumBaseline                           15.8
sumOfSquaresBaseline                  14.5
sumOfSquaresEvenBaseline             265.6
cartBaseline                          12.4
sumSeq                                73.5
sumSeqOpt                             17.5
sumOfSquaresSeq                      112.7
sumOfSquaresSeqOpt                    20.4
sumOfSquaresEvenSeq                  321.4
sumOfSquaresEvenSeqOpt               261.8
cartSeq                              179.8
cartSeqOpt                            12.7
sumPar                                62.2
sumParOpt                             24.1
sumOfSquaresPar                       70.3
sumOfSquaresParOpt                    10.5
sumOfSquaresEvenPar                  151.1
sumOfSquaresEvenParOpt               105.9
cartPar                               82.8
cartParOpt                             7.2

F#
--
sumBaseline                           11.3
sumofSquaresBaseline                  14.7
sumofSquaresEvenBaseline             285.8
cartBaseline                           9.5
sumSeq                                69.3
sumSeqOpt                             12.7
sumOfSquaresSeq                      185.5
sumOfSquaresSeqOpt                    16.9
sumOfSquaresEvenSeq                  429.9
sumOfSquaresEvenSeqOpt               260.6
cartSeq                              316.1
cartSeqOpt                            12.1
sumPar                                25.3
sumParOpt                             13.7
sumOfSquaresPar                       62.1
sumOfSquaresParOpt                    10.4
sumOfSquaresEvenPar                  148.5
sumOfSquaresEvenParOpt               104.7
cartPar                               71.1
cartParOpt                             7.3

Windows 8.1 - with optimization flags
-----------------------
Java
----
(no compiler optimization flag)

Scala
-----
cartBaseline                 avgt        10        8.976        0.137    ms/op
cartPar                      avgt        10     3814.450     1088.111    ms/op
cartParBlitz                 avgt        10      230.023        8.794    ms/op
cartSeq                      avgt        10      255.882        8.921    ms/op
cartSeqBlitz                 avgt        10      196.869       93.529    ms/op
sumBaseline                  avgt        10       10.343        0.381    ms/op
sumOfSquarePar               avgt        10     1175.029       12.769    ms/op
sumOfSquareParBlitz          avgt        10       45.628        1.133    ms/op
sumOfSquareSeq               avgt        10       73.374        1.602    ms/op
sumOfSquareSeqBlitz          avgt        10       47.435        0.664    ms/op
sumOfSquaresBaseline         avgt        10       10.286        0.131    ms/op
sumOfSquaresEvenBaseline     avgt        10      228.861        5.242    ms/op
sumOfSquaresEvenPar          avgt        10     4742.848     3497.772    ms/op
sumOfSquaresEvenParBlitz     avgt        10      132.110        5.915    ms/op
sumOfSquaresEvenSeq          avgt        10      484.924       12.413    ms/op
sumOfSquaresEvenSeqBlitz     avgt        10      307.942        7.969    ms/op
sumPar                       avgt        10     1101.243       87.904    ms/op
sumParBlitz                  avgt        10        7.613        0.093    ms/op
sumSeq                       avgt        10       61.341        1.907    ms/op
sumSeqBlitz                  avgt        10       10.354        0.155    ms/op

C#
--
sumBaseline                           11.4 ms/op
sumSeq                                66.5 ms/op
sumSeqOpt                             12.3 ms/op
sumPar                                27.2 ms/op
sumParOpt                             11.1 ms/op
sumOfSquaresBaseline                  10.9 ms/op
sumOfSquaresSeq                      107.6 ms/op
sumOfSquaresSeqOpt                    14.6 ms/op
sumOfSquaresPar                       60.8 ms/op
sumOfSquaresParOpt                     8.8 ms/op
sumOfSquaresEvenBaseline             258.5 ms/op
sumOfSquaresEvenSeq                  317.7 ms/op
sumOfSquaresEvenSeqOpt               266.1 ms/op
sumOfSquaresEvenPar                  168.6 ms/op
sumOfSquaresEvenParOpt               101.1 ms/op
cartBaseline                           9.4 ms/op
cartSeq                              184.6 ms/op
cartSeqOpt                            11.9 ms/op
cartPar                                 73 ms/op
cartParOpt                             7.2 ms/op

F#
--
sumBaseline                           10.8 ms/op
sumSeq                                69.5 ms/op
sumSeqOpt                             10.8 ms/op
sumPar                                25.7 ms/op
sumParOpt                             10.6 ms/op
sumofSquaresBaseline                  11.5 ms/op
sumOfSquaresSeq                      188.5 ms/op
sumOfSquaresSeqOpt                    13.8 ms/op
sumOfSquaresPar                       57.3 ms/op
sumOfSquaresParOpt                     7.9 ms/op
sumofSquaresEvenBaseline             257.6 ms/op
sumOfSquaresEvenSeq                  434.2 ms/op
sumOfSquaresEvenSeqOpt                 262 ms/op
sumOfSquaresEvenPar                  154.3 ms/op
sumOfSquaresEvenParOpt               100.9 ms/op
cartBaseline                            10 ms/op
cartSeq                              308.5 ms/op
cartSeqOpt                            11.3 ms/op
cartPar                               67.9 ms/op
cartParOpt                               7 ms/op

Linux
=====
Ubuntu 3.11.0-20-generic, Java 8 (b132), x64, 4 Cores, 2.8 GHz, 2.0 GB mem -- no optimization flags
---------------------------------------------------------------------------------------------------
Mono JIT compiler version 3.4.0
-------------------------------
Java
----
cartBaseline                 avgt        10        8.781        0.031    ms/op
cartPar                      avgt        10       46.139        0.920    ms/op
cartSeq                      avgt        10       88.632        0.814    ms/op
sumBaseline                  avgt        10       10.402        0.052    ms/op
sumOfSquaresBaseline         avgt        10       10.450        0.097    ms/op
sumOfSquaresEvenBaseline     avgt        10       97.482        0.552    ms/op
sumOfSquaresEvenPar          avgt        10       58.170        7.138    ms/op
sumOfSquaresEvenSeq          avgt        10      114.008        0.975    ms/op
sumOfSquaresPar              avgt        10       34.753        0.334    ms/op
sumOfSquaresSeq              avgt        10       41.816        0.194    ms/op
sumPar                       avgt        10       21.990        0.262    ms/op
sumSeq                       avgt        10       42.011        0.208    ms/op


Scala
-----
cartBaseline                 avgt        10        8.745        0.042    ms/op
cartPar                      avgt        10     2874.991      645.259    ms/op
cartParBlitz                 avgt        10      255.720        4.273    ms/op
cartSeq                      avgt        10      267.996        8.349    ms/op
cartSeqBlitz                 avgt        10      198.948      106.261    ms/op
sumBaseline                  avgt        10       10.430        0.097    ms/op
sumOfSquarePar               avgt        10     1583.909       21.244    ms/op
sumOfSquareParBlitz          avgt        10       51.603        0.385    ms/op
sumOfSquareSeq               avgt        10       77.143        2.525    ms/op
sumOfSquareSeqBlitz          avgt        10       53.992        0.726    ms/op
sumOfSquaresBaseline         avgt        10       10.453        0.083    ms/op
sumOfSquaresEvenBaseline     avgt        10       97.469        0.546    ms/op
sumOfSquaresEvenPar          avgt        10     4251.675     3077.147    ms/op
sumOfSquaresEvenParBlitz     avgt        10      105.032        1.898    ms/op
sumOfSquaresEvenSeq          avgt        10      451.097        4.884    ms/op
sumOfSquaresEvenSeqBlitz     avgt        10      173.778        3.609    ms/op
sumPar                       avgt        10     1585.852       17.385    ms/op
sumParBlitz                  avgt        10        8.156        0.110    ms/op
sumSeq                       avgt        10       64.338        0.754    ms/op
sumSeqBlitz                  avgt        10       10.486        0.118    ms/op

C#
--
sumBaseline              	      29.2
sumOfSquaresBaseline     	      29.1
sumOfSquaresEvenBaseline 	     458.1
cartBaseline             	      27.2
sumSeq                   	     105.1
sumSeqOpt                	        31
sumOfSquaresSeq          	     253.3
sumOfSquaresSeqOpt       	      31.5
sumOfSquaresEvenSeq      	     627.5
sumOfSquaresEvenSeqOpt   	     464.2
cartSeq                  	     298.9
cartSeqOpt               	        27
sumPar                   	     465.3
sumParOpt                	      17.4
sumOfSquaresPar          	     516.2
sumOfSquaresParOpt       	      14.2
sumOfSquaresEvenPar      	     670.3
sumOfSquaresEvenParOpt   	     202.3
cartPar                  	     286.8
cartParOpt               	      14.5

F#
--
sumBaseline              	      29.4
sumofSquaresBaseline     	      28.9
sumofSquaresEvenBaseline 	     459.3
cartBaseline             	      27.1
sumSeq                   	     106.3
sumSeqOpt                	      31.2
sumOfSquaresSeq          	     232.7
sumOfSquaresSeqOpt       	      29.3
sumOfSquaresEvenSeq      	     711.4
sumOfSquaresEvenSeqOpt   	     464.1
cartSeq                  	     341.2
cartSeqOpt               	      26.4
sumPar                   	       449
sumParOpt                	      15.8
sumOfSquaresPar          	     496.3
sumOfSquaresParOpt       	      14.5
sumOfSquaresEvenPar      	     646.2
sumOfSquaresEvenParOpt   	     203.4
cartPar                  	     390.9
cartParOpt               	      12.2

Ubuntu with optimization flags
-----------------------
Java
----
(no compiler optimization flag)

Scala
-----
cartBaseline                 avgt        10        8.700        0.034    ms/op
cartPar                      avgt        10     2987.933      839.197    ms/op
cartParBlitz                 avgt        10      223.495        6.463    ms/op
cartSeq                      avgt        10      236.736        5.123    ms/op
cartSeqBlitz                 avgt        10      209.765       91.809    ms/op
sumBaseline                  avgt        10        9.197        0.049    ms/op
sumOfSquarePar               avgt        10     1497.408       10.094    ms/op
sumOfSquareParBlitz          avgt        10       44.776        0.348    ms/op
sumOfSquareSeq               avgt        10       68.432        2.094    ms/op
sumOfSquareSeqBlitz          avgt        10       46.915        0.357    ms/op
sumOfSquaresBaseline         avgt        10        9.183        0.119    ms/op
sumOfSquaresEvenBaseline     avgt        10       95.753        0.306    ms/op
sumOfSquaresEvenPar          avgt        10     2871.014      775.118    ms/op
sumOfSquaresEvenParBlitz     avgt        10       98.965        3.051    ms/op
sumOfSquaresEvenSeq          avgt        10      335.841        9.031    ms/op
sumOfSquaresEvenSeqBlitz     avgt        10      168.893       11.863    ms/op
sumPar                       avgt        10     1493.451        7.613    ms/op
sumParBlitz                  avgt        10        7.104        0.266    ms/op
sumSeq                       avgt        10       57.232        3.266    ms/op
sumSeqBlitz                  avgt        10        9.481        0.612    ms/op

C#
--
sumBaseline              	      26.4 ms/op
sumSeq                   	     104.3 ms/op
sumSeqOpt                	      27.6 ms/op
sumPar                   	     455.6 ms/op
sumParOpt                	      12.5 ms/op
sumOfSquaresBaseline     	      28.1 ms/op
sumOfSquaresSeq          	     249.9 ms/op
sumOfSquaresSeqOpt       	      27.1 ms/op
sumOfSquaresPar          	     509.1 ms/op
sumOfSquaresParOpt       	      13.5 ms/op
sumOfSquaresEvenBaseline 	     463.7 ms/op
sumOfSquaresEvenSeq      	     622.7 ms/op
sumOfSquaresEvenSeqOpt   	     463.3 ms/op
sumOfSquaresEvenPar      	     665.7 ms/op
sumOfSquaresEvenParOpt   	     202.6 ms/op
cartBaseline             	      26.3 ms/op
cartSeq                  	       291 ms/op
cartSeqOpt               	      26.2 ms/op
cartPar                  	     293.3 ms/op
cartParOpt               	        13 ms/op

F#
--
sumBaseline              	      26.8 ms/op
sumSeq                   	       105 ms/op
sumSeqOpt                	      27.8 ms/op
sumPar                   	     450.8 ms/op
sumParOpt                	      12.7 ms/op
sumofSquaresBaseline     	      27.5 ms/op
sumOfSquaresSeq          	     221.3 ms/op
sumOfSquaresSeqOpt       	      27.3 ms/op
sumOfSquaresPar          	     493.1 ms/op
sumOfSquaresParOpt       	      13.1 ms/op
sumofSquaresEvenBaseline 	       456 ms/op
sumOfSquaresEvenSeq      	     698.6 ms/op
sumOfSquaresEvenSeqOpt   	     460.5 ms/op
sumOfSquaresEvenPar      	     631.8 ms/op
sumOfSquaresEvenParOpt   	     200.1 ms/op
cartBaseline             	      26.2 ms/op
cartSeq                  	     332.8 ms/op
cartSeqOpt               	        26 ms/op
cartPar                  	     355.8 ms/op
cartParOpt               	        12 ms/op

