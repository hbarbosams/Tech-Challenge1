using Data.Context;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Dependencies;

public class ConfigureRepository
{
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddScoped<IContatoRepository, ContatoRepository>();
        
        serviceCollection.AddDbContext<TechChallengeContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("TechChallenge"))
        );
    }
}