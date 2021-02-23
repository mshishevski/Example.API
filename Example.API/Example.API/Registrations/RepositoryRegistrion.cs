using Example.API.DataAccess.Interfaces;
using Example.API.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Example.API.Registrations
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
