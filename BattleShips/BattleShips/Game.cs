using System.Collections.Generic;

namespace BattleShips
{
    public static class Game
    {
        public static Dictionary<string, double> damagedOrSunk(int[,] board, int[,] attacks)
        {
            Dictionary<string, double> result = new Dictionary<string, double>
            {
                {"sunk", 0},
                { "damaged", 0},
                { "notTouched", 0},
                { "points", 0}
            };

            // number, size
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            Dictionary<int, int> damageDictionary = new Dictionary<int, int>();
            int boardRows = board.GetLength(0);

            foreach (var position in board)
            {
                // постараться все сделать за один проход
                if (position != 0)
                {
                    if (dictionary.ContainsKey(position))
                    {
                        dictionary[position]++;
                    }
                    else
                    {
                        dictionary.Add(position, 1);
                    }
                }
            }

            for (int i = 0; i < attacks.Length / 2; i++)
            {
                int x = boardRows - attacks[i, 1];
                int y = attacks[i, 0] - 1;
                int boardValue = board[x, y];

                if (boardValue != 0)
                {
                    if (damageDictionary.ContainsKey(boardValue))
                    {
                        damageDictionary[boardValue]++;
                    }
                    else
                    {
                        damageDictionary.Add(boardValue, 1);
                    }
                }
            }

            foreach (var item in dictionary)
            {
                if (!damageDictionary.ContainsKey(item.Key))
                {
                    // если такого ключа нет, то корабля не поврежден
                    result["notTouched"]++;
                    result["points"]--;
                    continue;
                }

                if (item.Value - damageDictionary[item.Key] == 0)
                {
                    result["sunk"]++;
                    result["points"]++;
                    continue;
                }


                    result["damaged"]++;
                    result["points"] += 0.5;
                    continue;
            }

            return result;
        }
    }
}
