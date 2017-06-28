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
        public string LastOperationName { get; set; }
        public IList<IOperation> Operations { get; private set; }

        public Calc()
        {
            Operations = new List<IOperation>();
            Operations.Add(new SumOperation());
            Operations.Add(new DivOperation());
            Operations.Add(new MultiplicationOperation());
            Operations.Add(new SubtractionOperation());

            // директория с расширениями
            var extsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Extensions");
            if (!Directory.Exists(extsDirectory))
                return;
            var exts = Directory.GetFiles(extsDirectory, "*.dll");

            foreach (var dllName in exts)
            {
                GetOperation(dllName);
            }



        }
        private void GetOperation(string name)
        {
            if (!File.Exists(name))
                return;

            // загружаем саму сборку
            var assmbly = Assembly.LoadFrom(name);
            // получааем все типы/классы из нее
            var types = assmbly.GetTypes();
            // перебираем типы
            var searchInterface = typeof(IOperation);
            foreach (var t in types)
            {
                // находим тех, кто реализует интерфейся IOperation
                var interfaces = t.GetInterfaces();
                if (interfaces.Contains(searchInterface))
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
        }
        
        public double Execute(string name, double[] args)
        {
            return Execute(i => i.Name == name, args);
        }
        public double Execute(long code, double[] args)
        {
            return Execute(i => i.Code == code, args);
        }
        private double Execute(Func<IOperation, bool> selector, double[] args)
        {
            IOperation oper = Operations.FirstOrDefault(selector);
            if (oper != null)
            {
                var displayOper = oper as IDisplayOperation;

                LastOperationName = displayOper != null
                    ? displayOper.DisplayName 
                    : oper.Name;

                // вычисляем результат
                var result = oper.Execute(args);
                // отдаем пользователю
                return result;
            }
            throw new NotSupportedException("Не найдена запрашиваемая операция");
        }

        public double Execute(Func<double[], double> fun, double[] args)
        {
            // не реализован
            return fun(args);
        }
        [Obsolete("Используйте Execute('+', new[] {x,y}). Данная функция будет удалена в 4.0")]
        public double Sum(double X, double Y)
        {
            return Execute("+", new[] { X, Y });

        }
        public static double ToDouble(string arg)
        {
            double x;
            if (!double.TryParse(arg, out x))
            {
                /*Console.WriteLine("Неверно введен параметр. Попробуйте еще раз. Пример: -2,3");
                arg = Console.ReadLine();
                x = ToDouble(arg);*/
            }

            return x;
        }

    }
}
