using DomainLayer.Models;

namespace DomainLayer.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        int GetByName(string name);
    }
}
