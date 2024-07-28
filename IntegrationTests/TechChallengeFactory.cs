using Data.Context;
using IntegrationTests.Fixtures;
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

    public async Task InitializeAsync() => await PostgresFixture.InitializeAsync();
    async Task IAsyncLifetime.DisposeAsync() => await PostgresFixture.DisposeAsync();
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {

            var descriptorType =
                typeof(DbContextOptions<TechChallengeContext>);

            var descriptor = services
                .SingleOrDefault(s => s.ServiceType == descriptorType);

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<TechChallengeContext>(options =>
            {
                options.UseNpgsql(PostgresFixture.GetConnectionString());
            }, ServiceLifetime.Transient);

            var db = services.BuildServiceProvider().GetRequiredService<TechChallengeContext>();
            db.Database.Migrate();
        });
    }
    
}