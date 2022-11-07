using UserRegistration.DataAccess.DomainModels;
using UserRegistration.DataAccess.Models;

namespace UserRegistration.DataAccess.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<UserDto>?> GetAllAsync();

        public Task<UserDto?> GetByIdAsync(int userId);

        public Task<UserDto?> GetByCredentials(string email, string password);

        public Task<UserDto?> AddAsync(UserDto userDto);

        public Task<UserDto?> UpdateAsync(UserDto userDto);

        public Task<bool> DeleteAsync(int userId);

        public UserDto GenerateUserDto(User user);
    }
}
