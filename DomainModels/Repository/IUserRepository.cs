using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IUserRepository
    {
        User Create(User user);
        User Get(long Id);
        void Update(User user);
        void Delete(User user);
        IEnumerable<User> GetAll();
        bool IsValid(string name, string pass);
        User GetByName(string name);
    }
}
