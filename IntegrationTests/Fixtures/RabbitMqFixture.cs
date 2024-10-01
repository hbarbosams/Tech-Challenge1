using DotNet.Testcontainers.Builders;
using Testcontainers.PostgreSql;
using Testcontainers.RabbitMq;

namespace IntegrationTests.Fixtures;

public class RabbitMqFixture : IAsyncLifetime
{
    private readonly RabbitMqContainer _rabbitMqContainer = new RabbitMqBuilder()
        .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(5432))
        .Build();

    public string GetConnectionString()
    {
        return _rabbitMqContainer.GetConnectionString();
    }

    public Task InitializeAsync() => _rabbitMqContainer.StartAsync();

    public Task DisposeAsync() => _rabbitMqContainer.DisposeAsync().AsTask();
}