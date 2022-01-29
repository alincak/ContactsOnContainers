namespace ContactService.API.Domain.Entities
{
  public class ContactInfo
  {
    public string Id { get; set; }
    public string ContactId { get; set; }
    public ContactInfoType InfoType { get; set; }
    public string Value { get; set; }

    public enum ContactInfoType
    { 
      NoType = 0,
      Phone = 1,
      Email = 2,
      Location = 3
    }
  }
}
