using UserRegistration.DataAccess.DomainModels;

namespace UserRegistration.BusinessLogic.Interfaces
{
    public interface IUserRoleManager
    {
        public Task<List<UserRoleDto>?> GetAllAsync();

        public Task<UserRoleDto?> GetByIdAsync(int userRoleId);

        public Task<UserRoleDto?> AddAsync(int userId, UserRoleDto userRoleDto);

        public Task<UserRoleDto?> UpdateAsync(int userId, UserRoleDto userRoleDto);

        public Task<bool> DeleteAsync(int userRoleId);
    }
}
