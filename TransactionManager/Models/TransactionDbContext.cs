using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TransactionManager.Models
{
    public class TransactionDbContext : IdentityDbContext<ApplicationUser>
    {
        public TransactionDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public DbSet<Transaction> Transactions { get; set; }


        public static TransactionDbContext Create()
        {
            return new TransactionDbContext();
        }
    }
}