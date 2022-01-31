namespace Web.ApiGateway.Models.Contact
{
  public class ContactInfoVo
  {
    public ContactInfoType InfoType { get; set; }
    public string Value { get; set; }

    public enum ContactInfoType
    {
      Phone = 0,
      Email = 1,
      Location = 2
    }
  }
}
