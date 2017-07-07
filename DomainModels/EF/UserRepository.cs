using DomainModels.EF;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.EF
{
    public class UserRepository : IUserRepository
    {
        private CalcContext context { get; set; }

        public UserRepository()
        {
            this.context = new CalcContext();
        }
        public User Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            user.IsDeleted = true;
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public User Get(long Id)
        {
            
            return context.Users.FirstOrDefault(i => i.Id == Id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.Where(i => !i.IsDeleted).ToList();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(string name, string pass)
        {
            return context.Users.Count(i => i.Login == name && !i.IsDeleted && i.Password == pass) == 1;
        }

        public User GetByName(string name)
        {
            return context.Users.FirstOrDefault(u => u.Login == name);
        }

        public User Create1()
        {
            throw new NotImplementedException();
        }
    }
}
