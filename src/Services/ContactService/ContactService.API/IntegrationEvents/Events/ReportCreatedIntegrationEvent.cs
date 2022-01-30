using EventBus.Base.Events;

namespace ContactService.API.IntegrationEvents.Events
{
  public class ReportCreatedIntegrationEvent : IntegrationEvent
  {
    public string ReportId { get; set; }
    public IList<ReportDetailDto> Details { get; set; }

    public class ReportDetailDto
    {
      public string Location { get; set; }
      public int ContactCount { get; set; }
      public int PhoneNumberCount { get; set; }
    }
  }
}
