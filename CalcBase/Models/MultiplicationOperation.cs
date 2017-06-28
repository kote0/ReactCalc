using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcBase.Models
{
    public class MultiplicationOperation :Operation
    {
        public override long Code
        {
            get { return 4; }
        }

        public override string Name
        {
            get { return "*"; }
        }

        public override double Execute(double[] args)
        {
            var res = args[0];
            for (int i = 1; i < args.Length; i++)
            {
                res *= args[i];
            }
            return res;
        }
        public override string Description
        {
            get { return "Результат умножения называется произведением, а умножаемые числа — множителями или сомножителями"; }
        }
        public override string Type
        {
            get { return "Простая задача"; }
        }
    }
}
