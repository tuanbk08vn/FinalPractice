using System.Collections.Generic;

namespace DomainLayer.IRepository
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        bool Insert(T product);
        bool Update(int id);

        bool Delete(int id);

        T SelectOne(int id);

    }
}
