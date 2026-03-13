using ECommerceApp.Core.ServiceContracts;
using ECommerceApp.Core.Services;
using ECommerceApp.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace ECommerceApp.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the service collection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //TO DO: Add core services here, such as database context, repositories, etc.
        services.AddTransient<IUserService, UserService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}


