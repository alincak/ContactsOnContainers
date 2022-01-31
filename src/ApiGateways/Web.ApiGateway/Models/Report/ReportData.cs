namespace Web.ApiGateway.Models.Report
{
  public class ReportData
  {
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public ReportStatus Status { get; set; }
    public IList<ReportDetailsData> Details { get; set; }

    public enum ReportStatus
    {
      Preparing = 0,
      Completed = 1
    }
  }
}
