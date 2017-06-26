using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ReactCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            var calc = new Calc();

            Console.WriteLine("Hello, i'm Калькулятор");

            if (args.Length == 2)
            {
                x = ToInt(args[0], 83);
                y = ToInt(args[1], 70);
            }
            else
            {
                #region Ввод данных

                Console.WriteLine("Введите Х");
                var strx = Console.ReadLine();
                x = ToInt(strx);

                Console.WriteLine("Введите Y");
                var stry = Console.ReadLine();
                y = ToInt(stry, 99);

                #endregion
            }

            var result = calc.Sum(x, y);

            Console.WriteLine($"Сумма = {result}");
            Console.ReadKey();
        }
        /// <summary>
        /// Перевод строки в int
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="def">Если не удпалось распарсить, то возращаем 100</param>
        /// <returns></returns>
        private static int ToInt(string arg, int def = 100)
        {
            int x;
            if (!int.TryParse(arg, out x))
            {
                x = def;
            }

            return x;
        }
    }
}
