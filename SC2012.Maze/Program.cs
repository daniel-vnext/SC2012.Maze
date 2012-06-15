using System;
using System.Linq;

namespace SC2012.Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any()) return;

            Console.WriteLine(new GridParser().ParseGrid(args[0]));
        }
    }
}
