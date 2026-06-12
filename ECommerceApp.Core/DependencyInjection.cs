using Azure.Identity;
using ECommerceApp.Core.ServiceContracts;
using ECommerceApp.Core.Services;
using ECommerceApp.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;


namespace ECommerceApp.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the service collection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        //Add core services here, such as database context, repositories, etc.
        services.AddTransient<IUserService, UserService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        services.AddSingleton<GraphServiceClient>
        (
            provider => 
            {
                var scopes = new[] { "https://graph.microsoft.com/.default" };
                var options = new ClientSecretCredentialOptions() { AuthorityHost = AzureAuthorityHosts.AzurePublicCloud};
                var clientSecretCredential = new ClientSecretCredential(configuration["EntraID:TenantID"],
                    configuration["EntraID:ClientID"], configuration["EntraID:ClientSecret"], options);
                var graphClient = new GraphServiceClient(clientSecretCredential, scopes);
                return graphClient;
            }
        );
        return services;
    }
}


