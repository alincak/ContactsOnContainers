﻿using Consul;

namespace ReportService.API.Configurations.Extensions
{
  public static class ConsulRegistration
  {
    public static void ConfigureConsul(this WebApplicationBuilder builder)
    {
      builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
      {
        var address = builder.Configuration.GetValue<string>("ConsulConfig:Address");
        consulConfig.Address = new Uri(address);
      }));
    }

    public static IApplicationBuilder RegisterWithConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime, IConfiguration configuration)
    {
      var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();

      var loggingFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();

      var logger = loggingFactory.CreateLogger<IApplicationBuilder>();

      var uri = configuration.GetValue<Uri>("ConsulConfig:ServiceAddress");
      var serviceName = configuration.GetValue<string>("ConsulConfig:ServiceName");
      var serviceId = configuration.GetValue<string>("ConsulConfig:ServiceId");

      var registration = new AgentServiceRegistration()
      {
        ID = serviceId ?? "ReportService",
        Name = serviceName ?? "ReportService",
        Address = $"{uri.Host}",
        Port = uri.Port,
        Tags = new[] { serviceName, serviceId }
      };

      logger.LogInformation("Registering with Consul");
      consulClient.Agent.ServiceDeregister(registration.ID).Wait();
      consulClient.Agent.ServiceRegister(registration).Wait();

      lifetime.ApplicationStopping.Register(() =>
      {
        logger.LogInformation("Deregistering from Consul");
        consulClient.Agent.ServiceDeregister(registration.ID).Wait();
      });

      return app;
    }
  }
}