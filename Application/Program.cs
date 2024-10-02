using CrossCutting.Dependencies;
using Data.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

ConfigureRepository.ConfigureDependenciesRepository(builder.Services, builder.Configuration);
ConfigureService.ConfigureDependenciesService(builder.Services);

var configuration = builder.Configuration;
var servidor = configuration.GetSection("MassTransit")["Servidor"] ?? string.Empty;
var usuario = configuration.GetSection("MassTransit")["Usuario"] ?? string.Empty;
var senha = configuration.GetSection("MassTransit")["Senha"] ?? string.Empty;

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(servidor, "/", h =>
        {
            h.Username(usuario);
            h.Password(senha);
        });

        cfg.ConfigureEndpoints(context);
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// In�cio - Config Prometheus
var counter = Metrics.CreateCounter("TechChallenge", "Contador de requisi��es do projeto TechChallenge.",
    new CounterConfiguration
    {
        LabelNames = new[] { "method", "endpoint" }
    });

app.Use((context, next) =>
{
    counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
    return next();
});

app.UseMetricServer();
app.UseHttpMetrics();
;
// Fim - Config Prometheus

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetRequiredService<TechChallengeContext>();
        db.Database.Migrate();
        Console.WriteLine("Migrações executadas");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Erro ao realizar migração automática: {e.Message}, Detalhes: {e.InnerException?.Message}");
        throw new Exception(
            $"Erro ao realizar migração: {e.Message}");
    }    
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();

public partial class Program { }
