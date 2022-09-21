using API.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data{

    public class DataContext: IdentityDbContext<User>
    {
        public DataContext (DbContextOptions options): base (options){}


        public DbSet<Schedhule> Schedhules {get; set;}
         public DbSet<UserRole> UserRoles {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }



}