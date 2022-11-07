using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UserRegistration.DataAccess.Models;

namespace UserRegistration.DataAccess
{
    public class UserRegistrationDbContext : DbContext
    {
        public UserRegistrationDbContext(DbContextOptions<UserRegistrationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
            .HasIndex(u => u.Email)
                .IsUnique();

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //This will singularize all table names
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

        }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
