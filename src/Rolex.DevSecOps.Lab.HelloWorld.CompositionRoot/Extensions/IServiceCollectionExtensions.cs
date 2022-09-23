using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rolex.DevSecOps.Lab.HelloWorld.Core;

namespace Rolex.DevSecOps.Lab.HelloWorld.CompositionRoot.Extensions;

public static class IServiceCollectionExtensions
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<IHelloWorldIdGenerator, HelloWorldIdGenerator>();
        //services.AddScoped<IHelloWorldRepository, BankAccountRepository>();
        
        //var connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING");
        
        // services.AddDbContext<DatabaseContext>(options =>
        // {
        //     options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Rolex.DevSecOps.Lab.HelloWorld.Infrastructure"));
        // });
        
        services.AddMediatR(typeof(CoreModule));
    }
}