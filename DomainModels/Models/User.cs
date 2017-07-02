using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class User
    {
        public long Id { get; set; }
        public Guid Uid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
    }
}
