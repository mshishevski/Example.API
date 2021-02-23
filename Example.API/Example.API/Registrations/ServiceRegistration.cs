using Example.API.Infrastructure.ExternalAPIs;
using Example.API.Infrastructure.Interfaces;
using Example.API.Service.Interfaces;
using Example.API.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Example.API.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPersonsAPI, PersonsAPI>();

            return services;
        }
    }
}
