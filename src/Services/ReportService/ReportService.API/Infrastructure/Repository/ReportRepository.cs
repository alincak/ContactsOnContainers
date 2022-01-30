using MongoDB.Driver;
using ReportService.API.Configurations.Settings;
using ReportService.API.Domain.Entities;

namespace ReportService.API.Infrastructure.Repository
{
  public class ReportRepository : IReportRepository
  {
    private readonly IMongoCollection<Report> _reportCollection;

    public ReportRepository(IDatabaseSettings databaseSettings)
    {
      var client = new MongoClient(databaseSettings.ConnectionString);
      var db = client.GetDatabase(databaseSettings.DatabaseName);

      _reportCollection = db.GetCollection<Report>(databaseSettings.ReportCollectionName);
    }

    public Task<Report> CreateReportAsync()
    {
      throw new NotImplementedException();
    }

    public Task<IList<Report>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<Report> GetReportByIdAsync(string id)
    {
      throw new NotImplementedException();
    }
  }
}
