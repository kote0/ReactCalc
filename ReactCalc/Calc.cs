using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CalcBase.Models;

namespace ReactCalc
{
    public class Calc
    {
        public Calc()
        {
            Operations = new List<IOperation>();
            Operations.Add(new SumOperation());
            Operations.Add(new DivOperation());
            Operations.Add(new MultiplicationOperation());
            Operations.Add(new SubtractionOperation());

            #region Факториал
            //var dllName =Directory.GetCurrentDirectory() + "\\FactorialLibrary.dll";
            var dllName = @"E:\ReactCalc\ArithmeticLibrary\bin\Debug" + "\\ArithmeticLibrary.dll";

            if (!File.Exists(dllName))
            {
                return;
            }

            // загружаем саму сборку
            var assmbly = Assembly.LoadFrom(dllName);
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

            #endregion
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
                var result = oper.Execute(args);
                // отдаем пользователю
                return result;
            }
            throw new NotSupportedException("Не найдена запрашиваемая операция");
        }

        private double Execute(Func<double[], double> fun, double[] args)
        {
            // не реализован
            return fun(args);
        }



        [Obsolete("Используйте Execute('+', new[] {x,y}). Данная функция будет удалена в 4.0")]
        public double Sum(double X, double Y)
        {
            return Execute("+", new[] { X, Y });

        }

    }
}
