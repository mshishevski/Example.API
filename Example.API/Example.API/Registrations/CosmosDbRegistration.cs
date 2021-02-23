using Example.API.DataAccess.Containers;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.API.Registrations
{
    public static class CosmosDbRegistration
    {
        public static IServiceCollection AddCosmosDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("ConnectionStrings:CosmosDb");
            var DatabaseName = configuration.GetValue<string>("CosmosDb:Database");
            var accountContainerName = configuration.GetValue<string>("CosmosDb:AccountContainerName");



            services.AddSingleton(_ =>
            {
                var cosmosClient = new CosmosClient(connectionString);
                return cosmosClient;
            });

            services.AddScoped(p =>
            {
                var cosmosClient = p.GetService<CosmosClient>();
                var accountContainer = new AccountContainer(cosmosClient.GetContainer(DatabaseName, accountContainerName));
                return accountContainer;
            });

            return services;
        }
    }
}
