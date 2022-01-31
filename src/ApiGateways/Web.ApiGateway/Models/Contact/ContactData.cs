namespace Web.ApiGateway.Models.Contact
{
  public class ContactData
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public IList<ContactInfoData> ContactInfos { get; set; } = new List<ContactInfoData>();
  }
}
