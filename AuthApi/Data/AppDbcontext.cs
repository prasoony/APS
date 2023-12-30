

using AuthApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aps.services.AuthApi.Data
{
    public class AppDbcontext:IdentityDbContext<ApplicationUser >
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options): base(options) 
        {
        
        }

       public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }


    }
}
