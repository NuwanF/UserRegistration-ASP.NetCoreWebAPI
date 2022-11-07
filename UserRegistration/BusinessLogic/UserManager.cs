using UserRegistration.BusinessLogic.Interfaces;
using UserRegistration.DataAccess.DomainModels;
using UserRegistration.DataAccess.Repository.Interfaces;

namespace UserRegistration.BusinessLogic
{
    public class UserManager : IUserManager
    {
        internal IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<UserDto>?> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<UserDto?> GetByIdAsync(int userId)
        {
            return await userRepository.GetByIdAsync(userId);
        }

        public async Task<UserDto?> GetByCredentials(string username, string password)
        {
            return await userRepository.GetByCredentials(username, password);
        }

        public async Task<UserDto?> AddAsync(UserDto userDto)
        {
            return await userRepository.AddAsync(userDto);
        }

        public async Task<UserDto?> UpdateAsync(UserDto userDto)
        {
            return await userRepository.UpdateAsync(userDto);
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            return await userRepository.DeleteAsync(userId);
        }
    }
}
