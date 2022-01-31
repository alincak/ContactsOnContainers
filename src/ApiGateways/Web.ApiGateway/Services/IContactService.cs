using Web.ApiGateway.Models.Contact;

namespace Web.ApiGateway.Services
{
  public interface IContactService
  {
    Task<ContactVo> CreateContactAsync(ContactVo contact);
    Task<bool> DeleteContactAsync(string id);
    Task<IList<ContactVo>> GetAllAsync();
    Task<ContactVo> GetContactByIdAsync(string id);
  }
}
