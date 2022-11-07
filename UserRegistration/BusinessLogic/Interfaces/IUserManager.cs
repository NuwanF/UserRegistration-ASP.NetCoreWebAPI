using UserRegistration.DataAccess.DomainModels;

namespace UserRegistration.BusinessLogic.Interfaces
{
    public interface IUserManager
    {
        public Task<List<UserDto>?> GetAllAsync();

        public Task<UserDto?> GetByIdAsync(int userId);

        public Task<UserDto?> GetByCredentials(string email, string password);

        public Task<UserDto?> AddAsync(UserDto userDto);

        public Task<UserDto?> UpdateAsync(UserDto userDto);

        public Task<bool> DeleteAsync(int userId);
    }
}
