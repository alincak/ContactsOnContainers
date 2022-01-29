using ContactService.API.Domain.Entities;

namespace ContactService.API.Infrastructure.Repository
{
  public interface IContactRepository
  {
    Task<Contact> CreateAsync(Contact contact);
    Task<bool> DeleteAsync(string id);
    Task<ContactInfo> AddContactInfoAsync(ContactInfo.ContactInfoType infoType, string value);
    Task<bool> DeleteContactInfoAsync(string id);
    Task<IList<Contact>> GetAllAsync();
    Task<Contact> GetContactAsync(string id);
    Task<IList<ContactInfo>> GetContactInfosAsync(string contactId);
  }
}
