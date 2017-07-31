namespace FinalPractice.ViewModels
{
    public class WishListViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ProductId { get; set; }

        public ProductViewModel Product { get; set; }
    }
}