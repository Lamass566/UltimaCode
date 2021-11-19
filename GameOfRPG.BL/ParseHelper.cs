using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL
{
    public class ParseHelper
    {
        public double ParseDouble(string value)
        {
            while (true)
            {
                Console.Write($"Введите {value}: ");
                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine($"Ошибка {value}-а!");
                }
            }
        }
        public int ParseInt(string value)
        {
            while (true)
            {
                Console.Write($"Введите {value}: ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine($"Ошибка {value}-а!");
                }
            }
        }
    }
}
