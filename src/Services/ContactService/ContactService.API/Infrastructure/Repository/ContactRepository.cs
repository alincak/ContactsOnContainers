using ContactService.API.Configurations.Settings;
using ContactService.API.Domain.Entities;
using ContactsOnContainers.Shared.Helpers;
using MongoDB.Driver;

namespace ContactService.API.Infrastructure.Repository
{
  public class ContactRepository : IContactRepository
  {
    private readonly IMongoCollection<Contact> _contactCollection;
    private readonly IMongoCollection<ContactInfo> _contactInfoCollection;

    public ContactRepository(IDatabaseSettings databaseSettings)
    {
      var client = new MongoClient(databaseSettings.ConnectionString);
      var db = client.GetDatabase(databaseSettings.DatabaseName);

      _contactCollection = db.GetCollection<Contact>(databaseSettings.ContactCollectionName);
      _contactInfoCollection = db.GetCollection<ContactInfo>(databaseSettings.ContactInfoCollectionName);
    }

    public async Task<ContactInfo> AddContactInfoAsync(string contactId, ContactInfo.ContactInfoType infoType, string value)
    {
      var contact = await GetContactByIdAsync(contactId);
      if (contact == null)
      {
        return await TaskEmpty<ContactInfo>.Task;
      }

      var contactInfo = new ContactInfo(contactId, infoType, value);
      await _contactInfoCollection.InsertOneAsync(contactInfo);

      return contactInfo;
    }

    public async Task<Contact> CreateAsync(Contact contact)
    {
      await _contactCollection.InsertOneAsync(contact);

      return contact;
    }

    public async Task<bool> DeleteAsync(string id)
    {
      var result = await _contactCollection.DeleteOneAsync(x => x.Id == id);

      return result.DeletedCount > 0;
    }

    public async Task<bool> DeleteContactInfoAsync(string id)
    {
      var result = await _contactInfoCollection.DeleteOneAsync(x => x.Id == id);

      return result.DeletedCount > 0;
    }

    public async Task<IList<Contact>> GetAllAsync()
    {
      return await _contactCollection.Find(c => true).ToListAsync();
    }

    public async Task<Contact> GetContactByIdAsync(string id)
    {
      return await _contactCollection.Find(x => x.Id == id).FirstAsync();
    }

    public async Task<IList<ContactInfo>> GetContactInfosByContactIdAsync(string contactId)
    {
      return await _contactInfoCollection.Find(x => x.ContactId == contactId).ToListAsync();
    }
  }
}
