using ContactService.API.Infrastructure.Repository;
using ContactService.API.IntegrationEvents.Events;
using EventBus.Base.Abstraction;

namespace ContactService.API.IntegrationEvents.EventHandlers
{
  public class ReportStartedIntegrationEventHandler : IIntegrationEventHandler<ReportStartedIntegrationEvent>
  {
    private readonly IContactRepository _repository;
    private readonly ILogger<ReportStartedIntegrationEvent> _logger;

    public ReportStartedIntegrationEventHandler(IContactRepository repository, ILogger<ReportStartedIntegrationEvent> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    public async Task Handle(ReportStartedIntegrationEvent @event)
    {
      _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at ContactService.API - ({@IntegrationEvent})", @event.ReportId, @event);
    }
  }
}
