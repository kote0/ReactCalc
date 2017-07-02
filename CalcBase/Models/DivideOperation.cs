﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class DivideOperation : Operation
    {
        public override long Code
        {
            get { return 4; }
        }

        public override string Name
        {
            get { return "divide"; }
        }

        public override double Execute(double[] args)
        {
            return args[0]/args[1];
        }

        public override string DisplayName
        {
            get { return "Деление"; }
        }
    }
}
