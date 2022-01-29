using ContactService.API.Domain.Entities;

namespace ContactService.API.Models
{
  public class ContactInfoVo
  {
    public string Id { get; set; }
    public ContactInfo.ContactInfoType InfoType { get; set; }
    public string Value { get; set; }
  }
}
