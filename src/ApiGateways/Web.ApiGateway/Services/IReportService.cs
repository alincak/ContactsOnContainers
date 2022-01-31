using Web.ApiGateway.Models.Contact;
using Web.ApiGateway.Models.Report;

namespace Web.ApiGateway.Services
{
  public interface IReportService
  {
    Task<ReportData> CreateReportAsync();
    Task<IList<ReportData>> GetAllReportsAsync();
    Task<ReportData> GetReportByIdAsync(string id);
  }
}
