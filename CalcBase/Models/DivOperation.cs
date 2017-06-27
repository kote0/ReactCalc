using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcBase.Models
{

    public class DivOperation : Operation
    {
        public override long Code
        {
            get { return 3; }
        }

        public override string Name
        {
            get { return "/"; }
        }

        public override double Execute(double[] args)
        {
            var res = args[0];
            for (int i = 1; i < args.Length; i++)
            {
                res /= args[i];
            }
            return res;
        }
    }
}
