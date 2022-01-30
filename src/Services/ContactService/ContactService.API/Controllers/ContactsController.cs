using AutoMapper;
using ContactService.API.Domain.Entities;
using ContactService.API.Infrastructure.Repository;
using ContactService.API.Models;
using ContactsOnContainers.Shared.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ContactService.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactsController : ControllerBase
  {
    private readonly IContactRepository _repository;
    private readonly IMapper _mapper;

    public ContactsController(IContactRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet("infos")]
    [ProducesResponseType(typeof(CustomResponse<IList<ContactVo>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllContactInfos()
    {
      var list = await _repository.GetAllContactInfosAsync();

      IList<ContactInfoVo> infos = null;
      if (list != null && list.Any())
      {
        infos = _mapper.Map<IList<ContactInfoVo>>(list);
      }

      return CustomResponse<IList<ContactInfoVo>>.Success(infos, (int)HttpStatusCode.OK);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CustomResponse<IList<ContactVo>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
      var list = await _repository.GetAllAsync();

      IList<ContactVo> contacts = null;
      if (true)
      {
        contacts = _mapper.Map<IList<ContactVo>>(list);
      }

      return CustomResponse<IList<ContactVo>>.Success(contacts, (int)HttpStatusCode.OK);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomResponse<ContactVo>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CustomResponse<string>), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetContactByIdAsync(string id)
    {
      var contact = await _repository.GetContactByIdAsync(id);
      if (contact == null)
      {
        return NotFound();
      }

      var model = _mapper.Map<ContactVo>(contact);

      var contactInfos = await _repository.GetContactInfosByContactIdAsync(contact.Id);
      if (contactInfos != null && contactInfos.Any())
      {
        model.ContactInfos = _mapper.Map<IList<ContactInfoVo>>(contactInfos);
      }

      return CustomResponse<ContactVo>.Success(model, (int)HttpStatusCode.OK);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResultId<string>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateContactAsync([FromBody] ContactVo model)
    {
      var newContact = _mapper.Map<Contact>(model);

      var _contact = await _repository.CreateContactAsync(newContact);

      if (_contact == null) return BadRequest();

      if (model.ContactInfos != null && model.ContactInfos.Any())
      {
        var contactInfos = model.ContactInfos.Select(x => new ContactInfo(_contact.Id, (ContactInfo.ContactInfoType)x.InfoType, x.Value)).ToList();

        await _repository.UpdateContactInfosAsync(_contact.Id, contactInfos);
      }

      var result = new ResultId<string> { Id = _contact.Id };
      return CustomResponse<ResultId<string>>.Success(result, (int)HttpStatusCode.Created);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteContactByIdAsync(string id)
    {
      var result = await _repository.DeleteContactAsync(id);

      return result ? Ok() : BadRequest();
    }

  }
}
