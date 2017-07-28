using System.Collections.Generic;

namespace DomainLayer.IRepository
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        bool Insert(T product);
        bool Update(T product);

        bool Delete(int id);

        T SelectOne(int id);

    }
}
