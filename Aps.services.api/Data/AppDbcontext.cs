using Aps.services.api.Model;
using Microsoft.EntityFrameworkCore;

namespace Aps.services.api.Data
{
    public class AppDbcontext:DbContext 
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options): base(options) 
        {
        
        }

        public DbSet<Copoun> Copouns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Copoun>().HasData( new Copoun
            {
                CopounId = 1,
                CopounCode="10OFF",
                DiscountAmount = 10,
                MinAmount = 40
              

            });
            modelBuilder.Entity<Copoun>().HasData(new Copoun
            {
                CopounId = 2,
                CopounCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 40


            });
        }


    }
}
