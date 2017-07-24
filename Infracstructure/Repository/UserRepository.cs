using DomainLayer.IRepository;
using Infracstructure.DAL;
namespace Infracstructure.Repository
{
    class UserRepository : IUserRepository
    {
        private readonly MyContext _dbContext;
        public UserRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int GetUser()
        {
            return 1;
        }

        public void SetUser()
        {

        }
    }
}
