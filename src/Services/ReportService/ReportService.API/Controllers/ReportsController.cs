using AutoMapper;
using ContactsOnContainers.Shared.Models.ResponseModels;
using EventBus.Base.Abstraction;
using Microsoft.AspNetCore.Mvc;
using ReportService.API.Infrastructure.Repository;
using ReportService.API.IntegrationEvents.Events;
using ReportService.API.Models;
using System.Net;

namespace ReportService.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReportsController : ControllerBase
  {
    private readonly IReportRepository _repository;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public ReportsController(IReportRepository repository, IMapper mapper, IEventBus eventBus)
    {
      _repository = repository;
      _mapper = mapper;
      _eventBus = eventBus;
    }

    [HttpGet]
    [ProducesResponseType(typeof(CustomResponse<IList<ReportIndexVo>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllReports()
    {
      var list = await _repository.GetAllReportsAsync();

      IList<ReportIndexVo> reports = null;
      if (list != null && list.Any())
      {
        reports = _mapper.Map<IList<ReportIndexVo>>(list);
      }

      return CustomResponse<IList<ReportIndexVo>>.Success(reports, (int)HttpStatusCode.OK);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResultId<string>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateReportAsync()
    {
      var newReport = await _repository.CreateReportAsync();

      if (newReport == null) return BadRequest();

      var reportStartedEventModel = new ReportStartedIntegrationEvent(newReport.Id);
      _eventBus.Publish(reportStartedEventModel);

      var result = new ResultId<string> { Id = newReport.Id };
      return CustomResponse<ResultId<string>>.Success(result, (int)HttpStatusCode.Created);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomResponse<ReportVo>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetReportByIdAsync(string id)
    {
      var report = await _repository.GetReportByIdAsync(id);
      if (report == null)
      {
        return NotFound();
      }

      var model = _mapper.Map<ReportVo>(report);

      var details = await _repository.GetDetailsByReportIdAsync(report.Id);
      if (details != null && details.Any())
      {
        model.Details = _mapper.Map<IList<ReportDetailsVo>>(details);
      }

      return CustomResponse<ReportVo>.Success(model, (int)HttpStatusCode.OK);
    }

  }
}