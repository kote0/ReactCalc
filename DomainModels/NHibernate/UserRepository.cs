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
    public class UserRepository : IUserRepository
    {
        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(long Id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<User>(Id);
            }

        }

        public IEnumerable<User> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>()
                    .And(u => !u.IsDeleted)
                    .List();
            }
        }

        public User GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(User));

                criteria.Add(Restrictions.Eq("Login", name));

                return criteria.UniqueResult<User>();
            }
        }

        public bool IsValid(string name, string pass)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("Login", name))
                    .Add(Restrictions.Eq("Password", pass))
                    .Add(Restrictions.Eq("IsDeleted", false));

                var user = criteria.UniqueResult<User>();

                return user != null;
            }
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
