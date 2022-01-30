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

    public async Task UpdateContactInfosAsync(string contactId, IList<ContactInfo> contactInfos)
    {
      _contactInfoCollection.DeleteMany(x => x.ContactId == contactId);
      await _contactInfoCollection.InsertManyAsync(contactInfos);
    }

    public async Task<Contact> CreateContactAsync(Contact contact)
    {
      await _contactCollection.InsertOneAsync(contact);

      return contact;
    }

    public async Task<bool> DeleteContactAsync(string id)
    {
      var result = await _contactCollection.DeleteOneAsync(x => x.Id == id);

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

    public async Task<IList<ContactInfo>> GetAllContactInfosAsync()
    {
      return await _contactInfoCollection.Find(c => true).ToListAsync();
    }
  }
}
