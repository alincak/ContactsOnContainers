using Web.ApiGateway.Models.Contact;

namespace Web.ApiGateway.Services
{
  public interface IContactService
  {
    Task<ContactData> CreateContactAsync(ContactData contact);
    Task<bool> DeleteContactAsync(string id);
    Task<IList<ContactData>> GetAllAsync();
    Task<ContactData> GetContactByIdAsync(string id);
  }
}
