using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReactCalc
{
    public class Calc
    {
        public Calc()
        {
            Operations = new List<IOperation>();
            Operations.Add(new SumOperation());

            var dllName = Directory.GetCurrentDirectory()+"\\FactorialLibrary.dll";

            if (!File.Exists(dllName))
            {
                return;
            }

            // загружаем саму сборку
            var assmbly = Assembly.LoadFrom("FactorialLibrary.dll");
            // получааем все типы/классы из нее
            var types = assmbly.GetTypes();
            // перебираем типы
            foreach (var t in types)
            {
                // находим тех, кто реализует интерфейся IOperation
                var interfaces = t.GetInterfaces();
                if (interfaces.Contains(typeof(IOperation)))
                {
                    // создаем экземпляр найденного класса
                    var instance = Activator.CreateInstance(t) as IOperation;
                    if (instance != null)
                    {
                        // добавляем в наш список операций
                        Operations.Add(instance);
                    }
                }
            }
            // Operations.Add(new FactorialOperation());

        }
        public IList<IOperation> Operations { get; private set; }

        public double Execute(string name, double[] args)
        {
            return Execute(i => i.Name == name, args);
        }
        public double Execute(long code, double[] args)
        {
            return Execute(i => i.Code == code, args);
            /*// находим операцию по имени
            IOperation oper = Operations.FirstOrDefault(i => i.Code == code);
            if (oper != null)
            {
                // вычисляем результат
                // отдаем пользователю
                var result = oper.Execute(args);
                return result;
            }
            throw new Exception("Не найдена запрашиваемая операция");*/
        }
        private double Execute(Func<IOperation, bool> selector, double[] args)
        {
            IOperation oper = Operations.FirstOrDefault(selector);
            if (oper != null)
            {
                // вычисляем результат
                // отдаем пользователю
                var result = oper.Execute(args);
                return result;
            }
            throw new NotSupportedException("Не найдена запрашиваемая операция");
        }

        private double Execute(Func<double[], double> fun, double[] args)
        {
            return fun(args);
        }


        /// <summary>
        /// Калькулятор
        /// </summary>
        /// <param name="action">Действие</param>
        /// <param name="X">Первый параметр</param>
        /// <param name="Y">Второй параметр</param>
        /// <returns></returns>
        public string Action(string action, double X, double Y)
        {
            string res = "";
            double resultNumber = 0;
            switch (action)
            {
                case "/":
                    if (Y == 0)
                    {
                        res = "Невозможно делить на 0!";
                    }
                    else
                    {
                        resultNumber = X / Y;
                        res = $"{resultNumber}";
                    }
                    break;
                case "*":
                    resultNumber = X * Y;
                    res = $"{resultNumber}";
                    break;
                case "+":
                    resultNumber = X + Y;
                    res = $"{resultNumber}";
                    break;
                case "-":
                    resultNumber = X - Y;
                    res = $"{resultNumber}";
                    break;
                case "sqrt":
                    resultNumber = Math.Sqrt(X);
                    res = $"{resultNumber}";
                    break;
                case "^":
                    resultNumber = Math.Pow(X, Y);
                    res = $"{resultNumber}";
                    break;
                default:
                    res = "Неправильно введены данные";
                    break;
            }
            return res;
        }

        [Obsolete("Используйте Execute('+', new[] {x,y}). Данная функция будет удалена в 4.0")]
        public double Sum(double X, double Y)
        {
            return Execute("+", new[] { X, Y });

        }

    }
}
