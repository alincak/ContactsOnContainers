using AutoMapper;
using ReportService.API.Domain.Entities;
using ReportService.API.Models;

namespace ContactService.API.Mapping
{
  public class GeneralMapping : Profile
  {
    public GeneralMapping()
    {
      CreateMap<Report, ReportVo>().ReverseMap();
      CreateMap<ReportDetail, ReportDetailsVo>().ReverseMap();
    }
  }
}
