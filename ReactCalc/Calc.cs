using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc
{
    public class Calc
    {

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
                        res = $"Результат деления = {resultNumber}";   
                    }
                    break;
                case "*":
                    resultNumber = X * Y;
                    res = $"Результат умножения = {resultNumber}";
                    break;
                case "+":
                    resultNumber = X + Y;
                    res = $"Результат суммирования = {resultNumber}";
                    break;
                case "-":
                    resultNumber = X - Y;
                    res = $"Результат вычитания = {resultNumber}";
                    break;
                case "sqrt":
                    resultNumber = Math.Sqrt(X);
                    res = $"Результат получения квадратного корня = {resultNumber}";
                    break;
                default:
                    res = "Неправильно введены данные";
                    break;
            }
            return res;
        }
        
    }
}
