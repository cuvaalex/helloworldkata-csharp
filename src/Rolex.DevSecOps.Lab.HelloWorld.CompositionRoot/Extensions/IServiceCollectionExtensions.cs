using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rolex.DevSecOps.Lab.HelloWorld.Core;
using Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.HelloWorlds;
using Rolex.DevSecOps.Lab.HelloWorld.Infrastructure;
using Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Persistence;

namespace Rolex.DevSecOps.Lab.HelloWorld.CompositionRoot.Extensions;

public static class IServiceCollectionExtensions
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHelloWorldIdGenerator, HelloWorldIdGenerator>();
        services.AddScoped<IHelloWorldRepository, HelloWorldRepository>();
        
        //var connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING");
        
        services.AddDbContext<DatabaseContext>();
        
        services.AddMediatR(typeof(CoreModule));
    }
}