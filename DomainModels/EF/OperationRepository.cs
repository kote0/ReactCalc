using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.EF
{
    public class OperationRepository : IOperationRepository
    {
        private CalcContext context { get; set; }

        public OperationRepository()
        {
            this.context = new CalcContext();
        }
        public Operation Get(long Id)
        {
            return context.Operation.FirstOrDefault(i => i.Id == Id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return context.Operation.ToList();
        }

        public Operation Create()
        {
            throw new NotImplementedException();
        }

        public void Update(Operation item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Operation item)
        {
            throw new NotImplementedException();
        }

        public Operation GetByName(string name)
        {
            return context.Operation.FirstOrDefault(u => u.Name == name);
        }
    }
}
