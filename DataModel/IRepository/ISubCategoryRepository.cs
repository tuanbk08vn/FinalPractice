using DomainLayer.Models;

namespace DomainLayer.IRepository
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        int GetByName(string name);
    }
}
