using CalcBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticLibrary
{
    public class ArithmeticOperation : IOperation
    {
        public long Code
        {
            get { return 1001; }
        }

        public string Name
        {
            get { return "arithmetic"; }
        }

        public double Execute(double[] args)
        {
            return args.Average();
        }
    }
}
