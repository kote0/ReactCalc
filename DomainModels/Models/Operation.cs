using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class Operation
    {
        public long Id { get; set; }
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
    }
}
