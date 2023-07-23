using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoCraDev.Lab.HelloWorld.Core;
using SoCraDev.Lab.HelloWorld.Core.Domain.HelloWorlds;
using SoCraDev.Lab.HelloWorld.Infrastructure;
using SoCraDev.Lab.HelloWorld.Infrastructure.Persistence;

namespace SoCraDev.Lab.HelloWorld.CompositionRoot.Extensions;

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