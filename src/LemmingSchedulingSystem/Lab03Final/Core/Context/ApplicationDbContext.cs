using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Core.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(255));
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}