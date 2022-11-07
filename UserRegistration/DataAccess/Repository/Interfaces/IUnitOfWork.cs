using Microsoft.EntityFrameworkCore;
using UserRegistration.DataAccess.Models;

namespace UserRegistration.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<UserRole> UserRoles { get; }
        IBaseRepository<User> Users { get; }
        public void Commit();
        public Task<int> CommitAsync();
    }
}
