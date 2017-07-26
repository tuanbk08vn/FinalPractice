using DomainLayer.IUnitOfWork;
using ServiceLayer.IService;

namespace ServiceLayer.Service
{
    class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddToWishList(int userId)
        {

        }

        public void LoadMore()
        {

        }

        public void DeleteWishList()
        {

        }
    }
}
