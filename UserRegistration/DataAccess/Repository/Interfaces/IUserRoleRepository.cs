using UserRegistration.DataAccess.DomainModels;

namespace UserRegistration.DataAccess.Repository.Interfaces
{
    public interface IUserRoleRepository
    {
        public Task<List<UserRoleDto>?> GetAllAsync();

        public Task<UserRoleDto?> GetByIdAsync(int userRoleId);

        public Task<UserRoleDto?> AddAsync(int userId, UserRoleDto userRoleDto);

        public Task<UserRoleDto?> UpdateAsync(int userId, UserRoleDto userRoleDto);

        public Task<bool> DeleteAsync(int userRoleId);
    }
}
