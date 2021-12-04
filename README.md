# interview-question-rivers-count
This is my solution to an interview question I once was asked.

Here's the description:
-----------------------
You're given a two-dimensional array (a matrix) containing only 0s and 1s. Each 0 represents land, and each 1 represents part of a river. 
A river consists of any number of 1s that are either horizontally or vertically adjacent (but not diagonally adjacent). The number of adjacent 1s forming a river determine its size.

Here's the objective:
---------------------
Write a function that returns an array of the sizes of all rivers represented in the input matrix. The sizes don't need to be in any particular order.

Here's an example:
------------------
For example, given the following matrix:

           [ 1 0 0 1 0 ]
           [ 1 0 1 0 0 ]
           [ 0 0 1 0 1 ]
           [ 1 0 1 0 1 ]
           [ 1 0 1 1 0 ]

The answer should be `[1, 2, 2, 2, 5]` because:
1) there's a river of size 1 at this coordinate: `(0, 3)` <- 0 being the row index, and 3 being the column index for which there's a cell with the value of 1
2) there's a first river of size 2 at these coordinates: `(0,0)` & `(1,0)`
3) there's a second river of size 2 at these coordinates: `(3,0)` & `(4,0)`
4) there's a third river of size 2 at these coordinates: `(2,4)` & `(3,4)`
5) there's a river of size 5 at these coordinates: `(1,2)` & `(2,2)` & `(3,2)` & `(4,2)` & `(4,3)`

Note that row and column indexes are zero-based in my explanation above. 

Also, if you're familiar with the game of Battleship, this is pretty much the same thing.
