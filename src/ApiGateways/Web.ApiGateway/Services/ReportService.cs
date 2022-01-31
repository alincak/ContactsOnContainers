using Web.ApiGateway.Extensions;
using Web.ApiGateway.Models.Report;

namespace Web.ApiGateway.Services
{
  public class ReportService : IReportService
  {
    private readonly IHttpClientFactory httpClientFactory;
    private readonly IConfiguration configuration;

    private readonly HttpClient httpClient;

    public ReportService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
      this.httpClientFactory = httpClientFactory;
      this.configuration = configuration;

      this.httpClient = httpClientFactory.CreateClient("report");
    }

    public async Task<ReportData> CreateReportAsync()
    {
      return await httpClient.PostGetResponseAsync<ReportData, ReportData>(null);
    }

    public async Task<IList<ReportData>> GetAllReportsAsync()
    {
      var response = await httpClient.GetResponseAsync<IList<ReportData>>();

      return response;
    }

    public async Task<ReportData> GetReportByIdAsync(string id)
    {
      var response = await httpClient.GetResponseAsync<ReportData>(id);

      return response;
    }
  }

}
