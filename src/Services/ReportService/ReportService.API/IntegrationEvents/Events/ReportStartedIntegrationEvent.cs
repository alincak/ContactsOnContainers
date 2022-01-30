using EventBus.Base.Events;

namespace ReportService.API.IntegrationEvents.Events
{
  public class ReportStartedIntegrationEvent : IntegrationEvent
  {
    public string ReportId { get; set; }
  }
}
