using DomainLayer.Models;
using System.Collections.Generic;

namespace DomainLayer.IRepository
{
    public interface IRepository<T>
    {
        List<T> Get();
        bool Insert(T product);
        bool Update(int id);

        bool Delete(int id);

        T SelectOne(int id);

    }
}
