using Web.ApiGateway.Extensions;
using Web.ApiGateway.Models.Contact;

namespace Web.ApiGateway.Services
{
  public class ContactService : IContactService
  {
    private readonly IHttpClientFactory httpClientFactory;
    private readonly IConfiguration configuration;

    private readonly HttpClient httpClient;

    public ContactService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
      this.httpClientFactory = httpClientFactory;
      this.configuration = configuration;

      this.httpClient = httpClientFactory.CreateClient("contact");
    }

    public async Task<ContactData> CreateContactAsync(ContactData contact)
    {
      return await httpClient.PostGetResponseAsync<ContactData, ContactData>(contact);
    }

    public async Task<bool> DeleteContactAsync(string id)
    {
      return await httpClient.DeleteResponseAsync<bool>(id);
    }

    public async Task<IList<ContactData>> GetAllAsync()
    {
      var response = await httpClient.GetResponseAsync<IList<ContactData>>();

      return response;
    }

    public async Task<ContactData> GetContactByIdAsync(string id)
    {
      var response = await httpClient.GetResponseAsync<ContactData>(id);

      return response;
    }
  }

}
