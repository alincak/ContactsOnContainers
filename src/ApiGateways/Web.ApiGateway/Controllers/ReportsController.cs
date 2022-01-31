using ContactsOnContainers.Shared.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.ApiGateway.Models.Report;
using Web.ApiGateway.Services;

namespace Web.ApiGateway.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ReportsController : ControllerBase
  {
    private readonly IReportService reportService;

    public ReportsController(IReportService reportService)
    {
      this.reportService = reportService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(CustomResponse<IList<ReportData>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
      var reports = await reportService.GetAllReportsAsync();

      return CustomResponse<IList<ReportData>>.Success(reports, (int)HttpStatusCode.OK);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResultId<string>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateReportAsync()
    {
      var newReport = await reportService.CreateReportAsync();

      if (newReport == null) return BadRequest();

      var result = new ResultId<string> { Id = newReport.Id };
      return CustomResponse<ResultId<string>>.Success(result, (int)HttpStatusCode.Created);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomResponse<ReportData>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetReportByIdAsync(string id)
    {
      var report = await reportService.GetReportByIdAsync(id);
      if (report == null)
      {
        return NotFound();
      }

      return CustomResponse<ReportData>.Success(report, (int)HttpStatusCode.OK);
    }

  }
}
