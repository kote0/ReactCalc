﻿using DomainModels.EF;
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
        public User Create()
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string[]> Find(long id)
        {
            throw new NotImplementedException();
        }

        public User Get(long Id)
        {
            
            return context.Users
                .FirstOrDefault(i => i.Id == Id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

       
    }
}
