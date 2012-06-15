using System;
using System.Linq;

namespace SC2012.Maze
{
    public class GridParser
    {
        public CellType[,] ParseGrid(string input)
        {
            var allLines = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(allLines);
            var height = allLines.Length;
            var width = allLines[0].Length;

            var outputArray = new CellType[width,height];

            foreach (var y in Enumerable.Range(0, height))
            {
                var currentLine = allLines[y];
                var characters = currentLine.ToArray();

                foreach (var x in Enumerable.Range(0, width))
                {
                    outputArray[y, x] = GetCellType(characters[x]);
                }
            }

            return outputArray;
        }

        private CellType GetCellType(char input)
        {
            switch (input)
            {
                    default: throw new Exception(input.ToString());
                case '*':
                    return CellType.Wall;
                case '.':
                    return CellType.Clear;
                case '_':
                    return CellType.Ice;
                case '1':
                    return CellType.Player1;
                case '2':
                    return CellType.Player2;
                case 'F':
                    return CellType.Finish;
            }
        }
    }
}