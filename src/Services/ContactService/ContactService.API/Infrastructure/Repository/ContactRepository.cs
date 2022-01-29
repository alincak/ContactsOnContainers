using ContactService.API.Configurations.Settings;
using ContactService.API.Domain.Entities;
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

    public Task<ContactInfo> AddContactInfoAsync(ContactInfo.ContactInfoType infoType, string value)
    {
      throw new NotImplementedException();
    }

    public Task<Contact> CreateAsync(Contact contact)
    {
      throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
      throw new NotImplementedException();
    }

    public Task<bool> DeleteContactInfoAsync(string id)
    {
      throw new NotImplementedException();
    }

    public Task<IList<Contact>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<Contact> GetContactAsync(string id)
    {
      throw new NotImplementedException();
    }

    public Task<IList<ContactInfo>> GetContactInfosAsync(string contactId)
    {
      throw new NotImplementedException();
    }
  }
}
