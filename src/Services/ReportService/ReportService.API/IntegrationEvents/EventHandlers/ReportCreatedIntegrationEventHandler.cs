using EventBus.Base.Abstraction;
using ReportService.API.Infrastructure.Repository;
using ReportService.API.IntegrationEvents.Events;

namespace ReportService.API.IntegrationEvents.EventHandlers
{
  public class ReportCreatedIntegrationEventHandler : IIntegrationEventHandler<ReportCreatedIntegrationEvent>
  {
    private readonly IReportRepository _repository;
    private readonly ILogger<ReportCreatedIntegrationEvent> _logger;

    public ReportCreatedIntegrationEventHandler(IReportRepository repository, ILogger<ReportCreatedIntegrationEvent> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    public async Task Handle(ReportCreatedIntegrationEvent @event)
    {
      _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at ReportService.API - ({@IntegrationEvent})", @event.ReportId, @event);
    }
  }
}
