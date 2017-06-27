using CalcBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticLibrary
{
    class MaxOperation : IOperation
    {
        public long Code
        {
            get { return 1002; }
        }

        public string Name
        {
            get { return "max"; }
        }

        public double Execute(double[] args)
        {
            return args.Max();
        }
    }
}
