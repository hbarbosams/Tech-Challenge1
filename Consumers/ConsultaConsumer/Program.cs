using ConsultaConsumer;
using ConsultaConsumer.Events;
using CrossCutting.Dependencies;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var fila = configuration.GetSection("MassTransit")["NomeFilaConsulta"] ?? string.Empty;
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
                    e.Consumer<ContatoConsultadoConsumer>(context);
                });

                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<ContatoConsultadoConsumer>();
        });
    })
    .Build();

host.Run();
