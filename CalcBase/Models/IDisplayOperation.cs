using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcBase.Models
{
    public interface IDisplayOperation : IOperation
    {
        string DisplayName { get; }
        string Description { get; }
        string Author { get; }
        string Type { get; }
    }
}
