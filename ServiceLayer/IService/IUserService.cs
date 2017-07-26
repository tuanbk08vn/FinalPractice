namespace ServiceLayer.IService
{
    public interface IUserService
    {
        void AddToWishList(int userId);
        void LoadMore();

        void DeleteWishList();


    }
}