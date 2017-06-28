using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcBase.Models
{
    public class SubtractionOperation : Operation
    {
        public override long Code
        {
            get { return 2; }
        }

        public override string Name
        {
            get { return "-"; }
        }

        public override double Execute(double[] args)
        {
            var res = args[0];
            for (int i = 1; i < args.Length; i++)
            {
                res -= args[i];
            }
            return res;
        }
        public override string Type
        {
            get { return "Простая задача"; }
        }
    }
}
