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
        public override string DisplayName
        {
            get
            {
                return "Деление";
            }
        }
        public override string Description
        {
            get { return "Деле́ние (операция деления) — это одно из четырёх простейших арифметических действий, обратное умножению"; }
        }
        public override string Author
        {
            get
            {
                return "Яндекс.Математика";
            }
        }
        public override string Type
        {
            get { return "Простая задача"; }
        }
    }
}
