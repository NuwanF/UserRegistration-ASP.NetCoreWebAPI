using Microsoft.EntityFrameworkCore;
using UserRegistration.DataAccess.DomainModels;
using UserRegistration.DataAccess.Models;
using UserRegistration.DataAccess.Repository.Interfaces;

namespace UserRegistration.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserRegistrationDbContext context;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<IUserRepository> logger;
        public UserRepository(ILogger<IUserRepository> logger, UserRegistrationDbContext context, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public UserDto GenerateUserDto(User user)
        {
            UserDto userDto = new UserDto()
            {
                UserId = user.UserId,
                Forenames = user.Forenames,
                Surname = user.Surname,
                FullName = $"{user.Forenames} {user.Surname}",
                Phone = user.Phone,
                Email = user.Email,
                Password = user.Password,
                UserRoleId = user.UserRoleId,
                UserRoleName = user.UserRole?.UserRoleName
            };
            return userDto;
        }

        public async Task<List<UserDto>?> GetAllAsync()
        {
            try
            {
                var result = await context.Users
                    .Include(r => r.UserRole).ToListAsync();

                if (result == null)
                    return null;

                List<UserDto> userDtoList = new List<UserDto>();
                foreach (var user in result)
                {                    
                    userDtoList.Add(GenerateUserDto(user));
                }
                return userDtoList;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<UserDto?> GetByIdAsync(int userId)
        {
            try
            {
                var result = await context.Users.Include(r => r.UserRole).FirstOrDefaultAsync(x => x.UserId == userId);

                if (result == null)
                    return null;                

                return GenerateUserDto(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<UserDto?> GetByCredentials(string email, string password)
        {
            try
            {
                var result = await context.Users
                    .Include(r => r.UserRole)
                    .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

                if (result == null)
                    return null;

                return GenerateUserDto(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }

        }

        public async Task<UserDto?> AddAsync(UserDto userDto)
        {
            try
            {
                var result = context.Users.FirstOrDefault(x => x.Email.ToLower() == userDto.Email.ToLower());

                if (result != null)
                    throw new Exception("Email already exist");

                User user = new User()
                {
                    UserRoleId = userDto.UserRoleId,
                    Forenames = userDto.Forenames,
                    Surname = userDto.Surname,
                    Email = userDto.Email,
                    Phone = userDto.Phone,
                    Password = userDto.Password,
                    CreatedDate = DateTime.UtcNow
                };

                var record = await unitOfWork.Users.AddAsync(user);

                if (record == null)
                    throw new Exception("No records added");

                return await GetByIdAsync(record.UserId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<UserDto?> UpdateAsync(UserDto userDto)
        {
            try
            {
                var result = unitOfWork.Users.GetFirstOrDefault(userDto.UserId);

                if (result == null)
                    throw new Exception("No records found");

                result.UserRoleId = userDto.UserRoleId;
                result.Forenames = userDto.Forenames;
                result.Surname = userDto.Surname;
                result.Phone = userDto.Phone;
                result.Email = userDto.Email;
                result.Password = userDto.Password;
                result.ModifiedDate = DateTime.UtcNow;

                var record = await unitOfWork.Users.UpdateAsync(result);

                if (record == null)
                    throw new Exception("No records updated");

                return await GetByIdAsync(record.UserId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            try
            {
                var result = unitOfWork.Users.GetFirstOrDefault(userId);

                if (result == null)
                    throw new Exception("No records found");

                int recordsCount = await unitOfWork.Users.DeleteAsync(result);

                if (recordsCount == 0)
                    throw new Exception("No records deleted");

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return false;
            }
        }

    }
}

