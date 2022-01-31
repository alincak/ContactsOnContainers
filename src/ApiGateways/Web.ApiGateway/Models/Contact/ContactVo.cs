namespace Web.ApiGateway.Models.Contact
{
  public class ContactVo
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public IList<ContactInfoVo> ContactInfos { get; set; } = new List<ContactInfoVo>();
  }
}
