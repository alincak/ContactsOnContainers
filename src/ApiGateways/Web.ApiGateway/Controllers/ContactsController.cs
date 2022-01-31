using ContactsOnContainers.Shared.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.ApiGateway.Models.Contact;
using Web.ApiGateway.Services;

namespace Web.ApiGateway.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ContactsController : ControllerBase
  {
    private readonly IContactService contactService;

    public ContactsController(IContactService contactService)
    {
      this.contactService = contactService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(CustomResponse<IList<ContactData>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
      var contacts = await contactService.GetAllAsync();

      return CustomResponse<IList<ContactData>>.Success(contacts, (int)HttpStatusCode.OK);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomResponse<ContactData>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CustomResponse<string>), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetContactByIdAsync(string id)
    {
      var contact = await contactService.GetContactByIdAsync(id);
      if (contact == null)
      {
        return NotFound();
      }

      return CustomResponse<ContactData>.Success(contact, (int)HttpStatusCode.OK);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResultId<string>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateContactAsync([FromBody] ContactData model)
    {
      var _contact = await contactService.CreateContactAsync(model);

      if (_contact == null) return BadRequest();

      var result = new ResultId<string> { Id = _contact.Id };
      return CustomResponse<ResultId<string>>.Success(result, (int)HttpStatusCode.Created);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteContactByIdAsync(string id)
    {
      var result = await contactService.DeleteContactAsync(id);

      return result ? Ok() : BadRequest();
    }

  }
}
