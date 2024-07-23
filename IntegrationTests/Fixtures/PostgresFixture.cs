using Testcontainers.PostgreSql;

namespace IntegrationTests.Fixtures;

public class PostgresFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
        .WithImage("postgres:15-alpine")
        .WithPassword("Strong_password_123!")
        .Build();

    public string GetConnectionString()
    {
        return _postgres.GetConnectionString();
    }

    public Task InitializeAsync() => _postgres.StartAsync();

    public Task DisposeAsync() => _postgres.DisposeAsync().AsTask();
}