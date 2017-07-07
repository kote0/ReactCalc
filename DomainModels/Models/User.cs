using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            //OperationResult = new List<OperationResult>();
            //UserFavoriteResult = new List<UserFavoriteResult>();
        }

        public virtual long Id { get; set; }
        public virtual Guid Uid { get; set; }
        public virtual string Login { get; set; }
        public virtual string FIO { get; set; }
        public virtual string Password { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual ICollection<OperationResult> OperationResult { get; set; }
        public virtual ICollection<UserFavoriteResult> UserFavoriteResult { get; set; }
    }
}
