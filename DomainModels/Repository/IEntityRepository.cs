using System.Collections.Generic;

namespace DomainModels.Repository
{
    public interface IEntityRepository<T>
    {
        T Create();

        T Get(long id);

        void Update(T user);

        void Delete(T user);

        IEnumerable<T> GetAll();
    }
}