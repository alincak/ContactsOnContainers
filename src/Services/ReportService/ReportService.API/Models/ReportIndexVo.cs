namespace ReportService.API.Models
{
  public class ReportIndexVo
  {
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public int Status { get; set; }
  }
}
