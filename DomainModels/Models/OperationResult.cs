using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class OperationResult
    {
        public long Id { get; set; }
        public Guid Uid { get; set; }
        public User Author { get; set; }
        public Operation Operation { get; set; }
        public string InputData { get; set; }
        public double Result { get; set; }
        public int ExecutionTime { get; set; }
        public DateTime ExecutionDate { get; set; }

    }
}
