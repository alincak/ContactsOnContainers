using ContactService.API.Domain.Entities;

namespace ContactService.API.Infrastructure.Repository
{
  public interface IContactRepository
  {
    Task<Contact> CreateContactAsync(Contact contact);
    Task<bool> DeleteContactAsync(string id);
    Task UpdateContactInfosAsync(string contactId, IList<ContactInfo> contactInfos);
    Task<IList<Contact>> GetAllAsync();
    Task<IList<ContactInfo>> GetAllContactInfosAsync();
    Task<Contact> GetContactByIdAsync(string id);
    Task<IList<ContactInfo>> GetContactInfosByContactIdAsync(string contactId);
  }
}
