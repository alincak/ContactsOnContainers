using AutoMapper;
using ContactsOnContainers.Shared.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using ReportService.API.Infrastructure.Repository;
using ReportService.API.Models;
using System.Net;

namespace ReportService.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ReportsController : ControllerBase
  {
    private readonly IReportRepository _repository;
    private readonly IMapper _mapper;

    public ReportsController(IReportRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(CustomResponse<IList<ReportVo>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
      var list = await _repository.GetAllReportsAsync();

      IList<ReportVo> reports = null;
      if (true)
      {
        reports = _mapper.Map<IList<ReportVo>>(list);
      }

      return CustomResponse<IList<ReportVo>>.Success(reports, (int)HttpStatusCode.OK);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResultId<string>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateReportAsync()
    {
      var newReport = await _repository.CreateReportAsync();

      if (newReport == null) return BadRequest();

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