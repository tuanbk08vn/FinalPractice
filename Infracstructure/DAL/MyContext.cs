using System.Data.Entity;

namespace Infracstructure.DAL
{
    public class MyContext : DbContext
    {
        public MyContext() : base("FinalPractice")
        {
        }

        public static MyContext Create()
        {
            return new MyContext();
        }
    }
}