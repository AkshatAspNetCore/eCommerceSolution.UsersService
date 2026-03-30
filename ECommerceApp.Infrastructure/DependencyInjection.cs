using ECommerceApp.Core.RepositoryContracts;
using Microsoft.Extensions.DependencyInjection;
using ECommerceApp.Infrastructure.Repositories;
using ECommerceApp.Infrastructure.DbContext;

namespace ECommerceApp.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the service collection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //Add infrastructure services here, such as database context, repositories, etc.
        services.AddTransient<IUsersRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}

