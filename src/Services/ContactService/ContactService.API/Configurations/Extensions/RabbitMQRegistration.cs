using ContactService.API.IntegrationEvents.EventHandlers;
using ContactService.API.IntegrationEvents.Events;
using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using RabbitMQ.Client;

namespace ContactService.API.Configurations.Extensions
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
          SubscriberClientAppName = "ContactService",
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

      eventBus.Subscribe<ReportStartedIntegrationEvent, ReportStartedIntegrationEventHandler>();
    }
  }
}
