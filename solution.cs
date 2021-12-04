using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Cell
    {
        public int Value { get; set; }
        public int RowPosition { get; set; }
        public int ColumnPosition { get; set; }

        public override string ToString()
        {
            return $"({RowPosition}, {ColumnPosition}) -> {Value}";
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var matrix = new List<int[]>
                         {
                             new[] { 1, 0, 0, 1, 0 },
                             new[] { 1, 0, 1, 0, 0 },
                             new[] { 0, 0, 1, 0, 1 },
                             new[] { 1, 0, 1, 0, 1 },
                             new[] { 1, 0, 1, 1, 0 }
                         }.ToArray();
            var riverSizes = CalculateRiverSizes(matrix: matrix);
        }

        private static List<Cell> GetAdjacentCells(int[][] matrix,
                                                   int rowPosition,
                                                   int columnPosition)
        {
            var matrixLength = matrix[0].Length;
            var result = new List<Cell>();
            if (rowPosition < matrixLength - 1)
                result.Add(new Cell { RowPosition = rowPosition + 1, ColumnPosition = columnPosition, Value = matrix[rowPosition + 1][columnPosition] });
            if (rowPosition > 0)
                result.Add(new Cell { RowPosition = rowPosition - 1, ColumnPosition = columnPosition, Value = matrix[rowPosition - 1][columnPosition] });
            if (columnPosition - 1 >= 0)
                result.Add(new Cell { RowPosition = rowPosition, ColumnPosition = columnPosition - 1, Value = matrix[rowPosition][columnPosition - 1] });
            if (columnPosition + 1 < matrixLength)
                result.Add(new Cell { RowPosition = rowPosition, ColumnPosition = columnPosition + 1, Value = matrix[rowPosition][columnPosition + 1] });
            return result;
        }

        private static int[] CalculateRiverSizes(int[][] matrix)
        {
            var riverSizes = new List<int>();
            for (var rowPosition = 0; rowPosition < matrix.Length; rowPosition++)
            for (var columnPosition = 0; columnPosition < matrix[rowPosition].Length; columnPosition++)
                if (matrix[rowPosition][columnPosition] == 1)
                {
                    matrix[rowPosition][columnPosition] = -1;
                    var currentRiverLength = 1 + GetRiverSize(matrix: matrix, rowPosition: rowPosition, columnPosition: columnPosition);
                    riverSizes.Add(item: currentRiverLength);
                }

            return riverSizes.OrderBy(_ => _).ToArray();
        }

        private static int GetRiverSize(int[][] matrix,
                                        int rowPosition,
                                        int columnPosition)
        {
            var riverSize = 0;
            var adjacentCells = GetAdjacentCells(matrix: matrix, rowPosition: rowPosition, columnPosition: columnPosition);
            foreach (var adjacentCell in adjacentCells)
                if (matrix[adjacentCell.RowPosition][adjacentCell.ColumnPosition] == 1)
                {
                    matrix[adjacentCell.RowPosition][adjacentCell.ColumnPosition] = -1;
                    riverSize = 1 + GetRiverSize(matrix: matrix, rowPosition: adjacentCell.RowPosition, columnPosition: adjacentCell.ColumnPosition);
                }
            return riverSize;
        }
    }
}
