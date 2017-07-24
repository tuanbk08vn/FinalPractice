using FinalPractice.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FinalPractice.DAL
{
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext()
            : base("FinalPractice", throwIfV1Schema: false)
        {
        }

        public static MyContext Create()
        {
            return new MyContext();
        }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}