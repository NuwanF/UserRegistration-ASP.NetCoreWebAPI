using Microsoft.AspNetCore.Identity;
using UserRegistration.BusinessLogic;
using UserRegistration.BusinessLogic.Interfaces;
using UserRegistration.DataAccess.Repository.Interfaces;
using UserRegistration.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace UserRegistration.Helper
{
    public static class DIRegistry
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IUserManager, UserManager>()
                .AddTransient<IUserRoleRepository, UserRoleRepository>()
                .AddTransient<IUserRoleManager, UserRoleManager>();
            return services;
        }
    }
}
