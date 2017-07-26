using System.Data.Entity;
using DomainLayer.Models;

namespace Infracstructure.DAL
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("FinalPractice")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MyContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public static MyContext Create()
        {
            return new MyContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<WishList> WishLists { get; set; }


    }
}