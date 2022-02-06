﻿using AutoMapper;
using ContactService.API.Domain.Entities;
using ContactService.API.Models;

namespace ContactService.UnitTests.Mapping
{
  public class GeneralMapping : Profile
  {
    public GeneralMapping()
    {
      CreateMap<Contact, ContactVo>().ReverseMap();
      CreateMap<Contact, ContactIndexVo>().ReverseMap();
      CreateMap<Contact, ContactEditVo>().ReverseMap();
      CreateMap<ContactInfo, ContactInfoVo>().ReverseMap();
    }
  }
}
