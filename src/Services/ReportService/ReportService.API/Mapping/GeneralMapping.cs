using AutoMapper;
using ReportService.API.Domain.Entities;
using ReportService.API.Models;

namespace ReportService.API.Mapping
{
  public class GeneralMapping : Profile
  {
    public GeneralMapping()
    {
      CreateMap<Report, ReportVo>().ReverseMap();
      CreateMap<Report, ReportIndexVo>().ReverseMap();
      CreateMap<ReportDetail, ReportDetailsVo>().ReverseMap();
    }
  }
}
