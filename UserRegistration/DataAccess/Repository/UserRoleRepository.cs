using UserRegistration.BusinessLogic.Interfaces;
using UserRegistration.DataAccess.DomainModels;
using UserRegistration.DataAccess.Models;
using UserRegistration.DataAccess.Repository.Interfaces;

namespace UserRegistration.DataAccess.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly UserRegistrationDbContext context;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<UserRoleRepository> logger;
        public UserRoleRepository(ILogger<UserRoleRepository> logger, UserRegistrationDbContext context, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        private UserRoleDto GenerateUserRoleDto(UserRole supplier)
        {
            UserRoleDto supplierDto = new UserRoleDto()
            {
                UserRoleId = supplier.UserRoleId,
            };
            return supplierDto;
        }

        public async Task<List<UserRoleDto>?> GetAllAsync()
        {
            try
            {
                var result = await unitOfWork.UserRoles.GetAllAsync();

                if (result == null)
                    return null;

                List<UserRoleDto> supplierDtoList = new List<UserRoleDto>();
                foreach (var supplier in result)
                {
                    supplierDtoList.Add(GenerateUserRoleDto(supplier));
                }
                return supplierDtoList;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<UserRoleDto?> GetByIdAsync(int supplierId)
        {
            try
            {
                var result = await unitOfWork.UserRoles.GetFirstOrDefaultAsnyc(supplierId);

                if (result == null)
                    return null;

                return GenerateUserRoleDto(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<UserRoleDto?> AddAsync(int userId, UserRoleDto supplierDto)
        {
            try
            {
                UserRole supplier = new UserRole()
                {

                };
                var record = await unitOfWork.UserRoles.AddAsync(supplier);

                if (record == null)
                    throw new Exception("No records added");

                return GenerateUserRoleDto(record);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<UserRoleDto?> UpdateAsync(int userId, UserRoleDto supplierDto)
        {
            try
            {
                var result = unitOfWork.UserRoles.GetFirstOrDefault(supplierDto.UserRoleId);

                if (result == null)
                    throw new Exception("No records found");

                var record = await unitOfWork.UserRoles.UpdateAsync(result);

                if (record == null)
                    throw new Exception("No records updated");

                return GenerateUserRoleDto(record);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int supplierId)
        {
            try
            {
                var result = unitOfWork.UserRoles.GetFirstOrDefault(supplierId);

                if (result == null)
                    throw new Exception("No records found");

                int recordsCount = await unitOfWork.UserRoles.DeleteAsync(result);

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
