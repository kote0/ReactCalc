﻿using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.EF
{
    public class LikeRepository : ILikeRepository
    {
        private CalcContext context { get; set; }
        public LikeRepository()
        {
            this.context = new CalcContext();
        }
        public UserFavoriteResult Create()
        {
            return new UserFavoriteResult();
        }

        public void Delete(UserFavoriteResult item)
        {

            context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public UserFavoriteResult Get(long id)
        {
            return context.UserFavoriteResult.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<UserFavoriteResult> GetAll()
        {
            return context.UserFavoriteResult.ToList();
        }

        public void Update(UserFavoriteResult result)
        {
            context.Entry(result).State = result.Id == 0
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
