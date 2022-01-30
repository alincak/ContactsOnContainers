namespace ReportService.API.Models
{
  public class ReportVo
  {
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public int Status { get; set; }
    public IList<ReportDetailsVo> Details { get; set; }
  }
}
