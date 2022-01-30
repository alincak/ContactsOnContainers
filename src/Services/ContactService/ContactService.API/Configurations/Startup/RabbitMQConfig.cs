using ContactService.API.IntegrationEvents.EventHandlers;
using ContactService.API.IntegrationEvents.Events;
using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using RabbitMQ.Client;

namespace ContactService.API.Configurations.Startup
{
  public class RabbitMQConfig
  {
    public void ConfigureService(IServiceCollection services)
    {
      services.AddSingleton(sp =>
      {
        EventBusConfig config = new()
        {
          ConnectionRetryCount = 5,
          EventNameSuffix = "IntegrationEvent",
          SubscriberClientAppName = "OrderService",
          Connection = new ConnectionFactory()
          {
            HostName = "c_rabbitmq"
          },
          EventBusType = EventBusType.RabbitMQ,

        };

        return EventBusFactory.Create(config, sp);
      });
    }

    public void ConfigureEventBusForSubscription(IApplicationBuilder app)
    {
      var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

      eventBus.Subscribe<ReportStartedIntegrationEvent, ReportStartedIntegrationEventHandler>();
    }
  }
}
