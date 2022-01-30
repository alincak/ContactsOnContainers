using ReportService.API.Domain.Entities;

namespace ReportService.API.Infrastructure.Repository
{
  public interface IReportRepository
  {
    Task<Report> CreateReportAsync();
    Task<IList<Report>> GetAllAsync();
    Task<Report> GetReportByIdAsync(string id);
  }
}
