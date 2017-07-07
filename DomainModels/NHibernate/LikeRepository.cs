using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using NHibernate;
using NHibernate.Criterion;

namespace DomainModels.NHibernate
{
    public class LikeRepository : ILikeRepository
    {
        public UserFavoriteResult Create()
        {
            return new UserFavoriteResult();
        }

        public void Delete(UserFavoriteResult item)
        {
            throw new NotImplementedException();
        }

        public UserFavoriteResult Get(long id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<UserFavoriteResult>(id);
            }
        }

        public IEnumerable<UserFavoriteResult> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<UserFavoriteResult>()
                    .List();
            }
        }

        public void Update(UserFavoriteResult item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(item);
                    transaction.Commit();
                }
            }
        }
    }
}
