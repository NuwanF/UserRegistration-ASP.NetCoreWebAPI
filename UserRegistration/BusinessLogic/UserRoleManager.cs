using UserRegistration.BusinessLogic.Interfaces;
using UserRegistration.DataAccess.DomainModels;
using UserRegistration.DataAccess.Repository.Interfaces;

namespace UserRegistration.BusinessLogic
{
    public class UserRoleManager : IUserRoleManager
    {
        IUserRoleRepository userRoleRepository;
        public UserRoleManager(IUserRoleRepository userRoleRepository)
        {
            this.userRoleRepository = userRoleRepository;
        }
        public async Task<List<UserRoleDto>?> GetAllAsync()
        {
            return await userRoleRepository.GetAllAsync();
        }

        public async Task<UserRoleDto?> GetByIdAsync(int userRoleId)
        {
            return await userRoleRepository.GetByIdAsync(userRoleId);
        }

        public async Task<UserRoleDto?> AddAsync(int userId, UserRoleDto userRoleDto)
        {
            return await userRoleRepository.AddAsync(userId, userRoleDto);
        }

        public async Task<UserRoleDto?> UpdateAsync(int userId, UserRoleDto userRoleDto)
        {
            return await userRoleRepository.UpdateAsync(userId, userRoleDto);
        }

        public async Task<bool> DeleteAsync(int userRoleId)
        {
            return await userRoleRepository.DeleteAsync(userRoleId);
        }
    }
}
