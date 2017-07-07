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
    public class OperationRepository : IOperationRepository
    {
        public Operation Create()
        {
            return new Operation()
            {
                Uid = Guid.NewGuid()
            };
        }

        public void Delete(Operation item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete("Operation", item);

                    transaction.Commit();
                }
            }
        }

        public Operation Get(long id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Operation>(id);
            }
        }

        public IEnumerable<Operation> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Operation>()
                    .List();
            }
        }

        public Operation GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Operation>().And(o => o.Name == name).SingleOrDefault();
            }
        }

        public void Update(Operation item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate("Operation", item);

                    transaction.Commit();
                }
            }
        }
    
    }
}
