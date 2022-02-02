using ContactService.API.Domain.Entities;
using ContactService.API.Infrastructure.Repository;

namespace ContactService.API.Configurations
{
  public static class ManagerDBDummyData
  {
    public static async Task CreateDBDummyData(this IApplicationBuilder app)
    {
      var repository = app.ApplicationServices.GetRequiredService<IContactRepository>();

      var hasDocument = await repository.GetContactsHasDocumentForDummyDataAsync();
      if (hasDocument) return;

      await repository.CreateContactDummy1();
      await repository.CreateContactDummy2();
    }

    private static async Task CreateContactDummy1(this IContactRepository repository)
    {
      var newContact = new Contact("Hakan", "Bilir", "Company1");
      var contact = await repository.CreateContactAsync(newContact);

      var contactInfo1 = new ContactInfo(contact.Id, ContactInfo.ContactInfoType.Phone, "5311111111");
      var contactInfo2 = new ContactInfo(contact.Id, ContactInfo.ContactInfoType.Phone, "5322222222");
      var contactInfo3 = new ContactInfo(contact.Id, ContactInfo.ContactInfoType.Phone, "5344444444");
      var contactInfo4 = new ContactInfo(contact.Id, ContactInfo.ContactInfoType.Location, "istanbul");

      await repository.CreateContactInfoAsync(contactInfo1);
      await repository.CreateContactInfoAsync(contactInfo2);
      await repository.CreateContactInfoAsync(contactInfo3);
      await repository.CreateContactInfoAsync(contactInfo4);
    }

    private static async Task CreateContactDummy2(this IContactRepository repository)
    {
      var newContact = new Contact("Soner", "Hakan", "Company2");
      var contact = await repository.CreateContactAsync(newContact);

      var contactInfo1 = new ContactInfo(contact.Id, ContactInfo.ContactInfoType.Phone, "5333333333");
      var contactInfo2 = new ContactInfo(contact.Id, ContactInfo.ContactInfoType.Location, "ankara");

      await repository.CreateContactInfoAsync(contactInfo1);
      await repository.CreateContactInfoAsync(contactInfo2);
    }

  }
}
