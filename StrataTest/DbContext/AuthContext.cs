using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StrataTest.Domain;
using StrataTest.Models;

namespace StrataTest.DbContext
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BasketModel> Baskets { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}