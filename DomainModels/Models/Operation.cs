using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    [Table("Operation")]
    public class Operation
    {
        public virtual long Id { get; set; }
        public virtual Guid Uid { get; set; }
        public virtual string Name { get; set; }
        public virtual string FullName { get; set; }
        public virtual ICollection<OperationResult> OperationResult { get; set; } 
    }
}
