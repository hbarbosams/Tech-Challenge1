using Data.Context;
using IntegrationTests;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public abstract class BaseIntegrationTest
    : IClassFixture<TechChallengeFactory>,
        IDisposable
{
    private readonly IServiceScope _scope;
    protected HttpClient HttpClient;
    protected readonly TechChallengeContext DbContext;

    protected BaseIntegrationTest(TechChallengeFactory factory)
    {
        _scope = factory.Services.CreateScope();

        HttpClient = factory.Server.CreateClient();

        DbContext = _scope.ServiceProvider
            .GetRequiredService<TechChallengeContext>();
    }

    public void Dispose()
    {
        _scope?.Dispose();
        DbContext?.Dispose();
    }
}