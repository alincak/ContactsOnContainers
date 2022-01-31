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

    public async Task<ContactVo> CreateContactAsync(ContactVo contact)
    {
      return await httpClient.PostGetResponseAsync<ContactVo, ContactVo>(contact);
    }

    public async Task<bool> DeleteContactAsync(string id)
    {
      return await httpClient.DeleteResponseAsync<bool>(id);
    }

    public async Task<IList<ContactVo>> GetAllAsync()
    {
      var response = await httpClient.GetResponseAsync<IList<ContactVo>>();

      return response;
    }

    public async Task<ContactVo> GetContactByIdAsync(string id)
    {
      var response = await httpClient.GetResponseAsync<ContactVo>(id);

      return response;
    }
  }

}
