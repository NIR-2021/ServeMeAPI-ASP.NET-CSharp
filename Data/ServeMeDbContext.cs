using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServeMe_M2.Data.Configuration;
using ServeMe_M2.Model;

namespace ServeMe_M2.Data
{
    public class ServeMeDbContext : IdentityDbContext<ApiUser>
    {
        public ServeMeDbContext(DbContextOptions<ServeMeDbContext> options) : base(options)
        {

        }

        public DbSet<VendorModel> vendors{ get; set; }
        DbSet<UserModel> users { get; set; }

        public DbSet<Category> categories { get; set; }
        public DbSet<ServiceModel> services { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            /*builder.ApplyConfiguration(new VendorConfigiuration());*/
        }
    }
}
