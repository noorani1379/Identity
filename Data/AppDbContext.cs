using Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Identity.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
            
        }

        public DbSet<Product> products { get; set; }

     
    }
}
