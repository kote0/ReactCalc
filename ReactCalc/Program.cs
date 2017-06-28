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
            double x = 0d;
            double y = 0d;
            string action = "";
            var calc = new Calc();

            #region Инструкция
            Console.WriteLine("Hello, i'm Калькулятор");
            Console.WriteLine("Инструкция:");
            Console.WriteLine("'/' - деление");
            Console.WriteLine("'*' - умножение");
            Console.WriteLine("'-' - вычитание");
            Console.WriteLine("'+' - сумма");
            Console.WriteLine("'sqrt' - квадратный корень");
            #endregion


            if (args.Length >= 2)
            {
                action = args[0];
                x = ToDouble(args[1]);
                if (args.Length >= 3)
                {
                    y = ToDouble(args[2]);
                }
                else
                {
                    y = ToDouble(args[1]);
                }
            }
            else
            {
                #region Ввод данных

                Console.WriteLine("Введите действие");
                action = Console.ReadLine();

                Console.WriteLine("Введите Х");
                var strx = Console.ReadLine();
                x = ToDouble(strx);
                if (action != "sqrt")
                {
                    Console.WriteLine("Введите Y");
                    var stry = Console.ReadLine();
                    y = ToDouble(stry);
                }

                #endregion
            }

            try
            {
                var result = calc.Execute(action, new[] { x, y });
                Console.WriteLine("{0} = {1}", calc.LastOperationName, result);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Перевод строки в double
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private static double ToDouble(string arg)
        {
            double x;
            if (!double.TryParse(arg, out x))
            {
                Console.WriteLine("Неверно введен параметр. Попробуйте еще раз. Пример: -2,3");
                arg = Console.ReadLine();
                x = ToDouble(arg);
            }

            return x;
        }
    }
}
