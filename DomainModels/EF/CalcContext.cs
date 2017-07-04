using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.EF
{
    public class CalcContext : DbContext
    {
        public CalcContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ReactCalc\DomainModels\App_Data\reactCalc.mdf;Integrated Security=True")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<OperationResult> OperationResult { get; set; }
        public DbSet<UserFavoriteResult> UserFavoriteResult { get; set; }
    }
}
