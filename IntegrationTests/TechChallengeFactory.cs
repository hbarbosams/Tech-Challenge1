using Data.Context;
using IntegrationTests.Fixtures;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;

[CollectionDefinition(nameof(TechChallengeFactoryCollection))]
public class TechChallengeFactoryCollection : ICollectionFixture<TechChallengeFactory>;

public class TechChallengeFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private static readonly PostgresFixture PostgresFixture = new();
    private static readonly PostgresFixture RabbitMqFixture = new();

    public async Task InitializeAsync()
    {
        await PostgresFixture.InitializeAsync();
        await RabbitMqFixture.InitializeAsync();
    } 
    async Task IAsyncLifetime.DisposeAsync()
    {
        await PostgresFixture.DisposeAsync();
        await RabbitMqFixture.DisposeAsync();
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.Configure<MassTransitHostOptions>(options =>
            {
                options.WaitUntilStarted = true; // Configuração de espera para garantir que o bus comece antes dos testes
            });

            services.Configure<RabbitMqTransportOptions>(options =>
            {
                options.Host = "localhost";
                options.User = "guest";
                options.Pass = "guest";
            });
            
            services.Remove<DbContextOptions<TechChallengeContext>>();
            services.AddDbContext<TechChallengeContext>(options =>
            {
                options.UseNpgsql(PostgresFixture.GetConnectionString());
            }, ServiceLifetime.Transient);

            var db = services.BuildServiceProvider().GetRequiredService<TechChallengeContext>();
            db.Database.Migrate();
        });
    }
    
}