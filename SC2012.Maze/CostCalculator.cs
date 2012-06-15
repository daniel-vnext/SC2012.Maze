using System;
using System.Collections.Generic;

namespace SC2012.Maze
{
    public class CellCost
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Cost;

        public CellCost(int x, int y, int cost)
        {
            X = x;
            Y = y;
            Cost = cost;
        }
    }


    public class CostCalculator
    {
        private Dictionary<CellType, int> cellCosts = new Dictionary<CellType, int>
                                                          {
                                                              {CellType.Clear, 1},
                                                              {CellType.Ice, 0},
                                                              {CellType.Wall, int.MaxValue},
                                                              {CellType.Player1, int.MaxValue},
                                                              {CellType.Player2, int.MaxValue},
                                                              {CellType.Finish, 1},
                                                          };

        public IEnumerable<CellCost> Calculate(CellType[,] grid, int horizontalPosition, int verticalPosition)
        {
            var output = new List<CellCost>();

            if (horizontalPosition > 0)
            {
                var left = horizontalPosition - 1;
                var leftCell = grid[verticalPosition, left];
                output.Add( new CellCost(verticalPosition, left, GetCost(leftCell)));
            }

            if (horizontalPosition < grid.GetLength(1) - 1)
            {
                var right = horizontalPosition + 1;
                var leftCell = grid[verticalPosition, right];
                output.Add( new CellCost(verticalPosition, right, GetCost(leftCell)));
            }

            if (verticalPosition > 0)
            {
                var down = verticalPosition - 1;
                var leftCell = grid[down, horizontalPosition];
                output.Add( new CellCost(down, horizontalPosition, GetCost(leftCell)));
            }

            if (verticalPosition < grid.GetLength(0) - 1)
            {
                var up = verticalPosition + 1;
                var leftCell = grid[up, horizontalPosition];
                output.Add( new CellCost(up, horizontalPosition, GetCost(leftCell)));
            }

            return output;
        }

        private int GetCost(CellType leftCell)
        {
            return cellCosts[leftCell];
        }
    }
}