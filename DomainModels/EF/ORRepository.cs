using DomainModels.Models;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.EF
{
    public class ORRepository : IORepository
    {
        private CalcContext context { get; set; }
        public ORRepository()
        {
            this.context = new CalcContext();
        }
        

        public void Delete(OperationResult result)
        {
            context.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public OperationResult Get(long Id)
        {

            return context.OperationResult.FirstOrDefault(i => i.Id == Id);
        }

        public IEnumerable<OperationResult> GetAll()
        {
            return context.OperationResult.ToList();
        }

        public void Update(OperationResult result)
        {
            context.Entry(result).State = result.Id == 0
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public bool IsValid(string name, string pass)
        {
            throw new NotImplementedException();
        }

        public OperationResult Create()
        {
            return new OperationResult()
            {
                Uid = Guid.NewGuid()
            };
        }

        public double GetOldResult(long operationId, string InputData)
        {
            var rec = context.OperationResult.FirstOrDefault(
                u => u.OperationId == operationId
                && u.InputData == InputData
                );
            return rec != null ? rec.Result : Double.NaN;
        }
        public OperationResult GetByName(string name)
        {
            return context.OperationResult.FirstOrDefault(u => u.InputData == name);
        }
    }
}
