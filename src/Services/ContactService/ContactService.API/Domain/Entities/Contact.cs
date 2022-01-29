namespace ContactService.API.Domain.Entities
{
  public class Contact
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public IList<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();
  }
}