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
    public class ORRepository : IORepository
    {
        public OperationResult Create()
        {
            return new OperationResult()
            {
                Uid = Guid.NewGuid()
            };
        }

        public void Delete(OperationResult item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete("OperationResult", item);
                    transaction.Commit();
                }
            }
        }

        public OperationResult Get(long id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<OperationResult>(id);
            }
        }

        public IEnumerable<OperationResult> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<OperationResult>()
                    .List();
            }
        }
        public IEnumerable<OperationResult> GetByUser(User user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.QueryOver<OperationResult>();
                criteria = criteria.And(or => or.Author == user);
                return criteria.List();
            }
        }

        public double GetOldResult(Operation operationId, string InputData)
        {

            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.QueryOver<OperationResult>()
                   .And(it => it.Operation == operationId && it.InputData == InputData)
                   .OrderBy(it => it.ExecutionDate).Asc()
                   .Take(1);

                var result = criteria.SingleOrDefault();


                return result != null ? result.Result : Double.NaN;
            }
        }

        public OperationResult GetRecord(long userId, Operation operId, string inputData)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.QueryOver<OperationResult>()
                    .And(o => o.InputData == inputData && o.Operation == operId);
                return criteria.SingleOrDefault();
            }
        }

        public void Update(OperationResult item)
        {

            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    // -> 18
                    session.SaveOrUpdate("OperationResult", item);

                    transaction.Commit();
                }
            }
        }
    }
}
