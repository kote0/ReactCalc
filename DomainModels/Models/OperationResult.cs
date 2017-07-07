using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    [Table("OperationResult")]
    public class OperationResult
    {
        public virtual long Id { get; set; }
        public virtual Guid Uid { get; set; }
        [Obsolete]
        public virtual long AuthorId { get; set; }
        public virtual User Author { get; set; }
        [Obsolete]
        public virtual long OperationId { get; set; }
        public virtual Operation Operation { get; set; }
        public virtual string InputData { get; set; }
        public virtual double Result { get; set; }
        public virtual int ExecutionTime { get; set; }
        public virtual DateTime? ExecutionDate { get; set; }
        [NotMapped]
        public virtual bool IsLiked { get; set; }

    }
}
