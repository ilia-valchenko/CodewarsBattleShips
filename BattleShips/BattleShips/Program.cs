using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.IndexOutOfRangeException : Index was outside the bounds of the array.

            // -------------  1 ---------------

            //0,0,0,0,0,0
            //0,0,0,0,0,0
            //0,1,2,2,0,0
            //0,1,0,0,0,0
            //0,0,0,0,0,0
            //0,0,0,0,0,0
            //0,0,0,0,0,0

            ////Attacks
            //(4, 3)(4, 1)(2, 2)(4, 2)(1, 2)

            // -------------- 2 ----------------

            //0,0,0,0,0
            //0,0,0,0,0
            //0,0,0,0,0
            //0,2,2,0,0
            //0,0,0,0,0
            //0,0,0,0,0
            //0,0,0,0,0

            ////Attacks
            //(4, 1)(1, 2)(1, 1)(3, 1)(2, 1)(3, 2)(4, 2)(2, 2)

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int[,] board = { { 3, 0, 1 },
                             { 3, 0, 1 },
                             { 0, 2, 1 },
                             { 0, 2, 0 } };
            int[,] attacks = { { 2, 1 }, { 2, 2 }, { 3, 2 }, { 3, 3 } };

            var result = Game.damagedOrSunk(board, attacks);

            stopwatch.Stop();

            Console.WriteLine("RESULT:\n");

            foreach (var r in result)
            {
                Console.Write($"[{r.Key}, {r.Value}], ");
            }

            Console.WriteLine($"\n\nElapsed time: {stopwatch.Elapsed}");

            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }
    }
}
