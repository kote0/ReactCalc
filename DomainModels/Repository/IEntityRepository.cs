using System.Collections.Generic;

namespace DomainModels.Repository
{
    public interface IEntityRepository<T>
    {
        T Create();

        T Get(long id);

        void Update(T item);

        void Delete(T item);

        IEnumerable<T> GetAll();
    }
}