using CategoryBackend.AuthScope;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CategoryBackend.MyContext
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }
}
