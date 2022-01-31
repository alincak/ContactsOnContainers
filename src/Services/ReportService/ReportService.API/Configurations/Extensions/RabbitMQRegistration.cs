using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using RabbitMQ.Client;
using ReportService.API.IntegrationEvents.EventHandlers;
using ReportService.API.IntegrationEvents.Events;

namespace ReportService.API.Configurations.Extensions
{
  public static class RabbitMQRegistration
  {
    public static void ConfigureRabbitMQ(this IServiceCollection services)
    {
      services.AddSingleton(sp =>
      {
        EventBusConfig config = new()
        {
          ConnectionRetryCount = 5,
          EventNameSuffix = "IntegrationEvent",
          SubscriberClientAppName = "ReportService",
          Connection = new ConnectionFactory()
          {
            HostName = "c_rabbitmq"
          },
          EventBusType = EventBusType.RabbitMQ,

        };

        return EventBusFactory.Create(config, sp);
      });
    }

    public static void ConfigureEventBusForSubscription(this IApplicationBuilder app)
    {
      var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

      eventBus.Subscribe<ReportCreatedIntegrationEvent, ReportCreatedIntegrationEventHandler>();
    }
  }
}
