using CrossCutting.Dependencies;
using ExclusaoConsumer;
using ExclusaoConsumer.Events;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var fila = configuration.GetSection("MassTransit")["NomeFilaExclusao"] ?? string.Empty;
        var servidor = configuration.GetSection("MassTransit")["Servidor"] ?? string.Empty;
        var usuario = configuration.GetSection("MassTransit")["Usuario"] ?? string.Empty;
        var senha = configuration.GetSection("MassTransit")["Senha"] ?? string.Empty;

        services.AddHostedService<Worker>();
        ConfigureRepository.ConfigureDependenciesRepository(services, configuration);
        ConfigureService.ConfigureDependenciesService(services);

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(servidor, "/", h =>
                {
                    h.Username(usuario);
                    h.Password(senha);
                });
                cfg.ReceiveEndpoint(fila, e =>
                {
                    e.Consumer<ContatoExcluidoConsumer>(context);
                });

                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<ContatoExcluidoConsumer>();
        });
    })
    .Build();

host.Run();
