using UserRegistration.DataAccess.Models;
using UserRegistration.DataAccess.Repository.Interfaces;

namespace UserRegistration.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserRegistrationDbContext context;

        private BaseRepository<UserRole> userRole;
        private BaseRepository<User> user;
        public UnitOfWork(UserRegistrationDbContext context)
        {
            this.context = context;
        }

        public IBaseRepository<UserRole> UserRoles
        {
            get
            {
                return userRole ??
                    (userRole = new BaseRepository<UserRole>(context));
            }
        }

        public IBaseRepository<User> Users
        {
            get
            {
                return user ??
                    (user = new BaseRepository<User>(context));
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
