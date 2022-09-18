using AutoMapper;
using ContactApp.Business.Interfaces;
using ContactApp.Core.Entities;
using ContactApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        /// <summary>
        /// Gets the list of all contacts
        /// </summary>
        /// <remarks>Type of the returned list: IEnumerable of Contact</remarks>
        /// <returns>Returns a list of contacts</returns>
        /// <response code="200">Success</response>
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContactsAsync() =>
            Ok(await _contactService.GetAllContactsAsync());

        /// <summary>
        /// Gets the contact by id
        /// </summary>
        /// <param name="id">Contact id of type Guid</param>
        /// <returns>Returns found contact or NotFound</returns>
        /// <response code="200">Success</response>
        /// <response code="404">If contact is not found</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactAsync(Guid id)
        {
            var contact = await _contactService.GetContactAsync(id);

            if (contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        /// <summary>
        /// Creates the contact
        /// </summary>
        /// <param name="createModel">Contact to create</param>
        /// <returns>Returns guid of the created contact</returns>
        /// <response code="200">Success</response>
        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateContactAsync(CreateContactModel createModel)
        {
            var id = await _contactService.CreateContactAsync(_mapper.Map<Contact>(createModel));

            return Ok(id);
        }

        /// <summary>
        /// Deletes the contact by the id
        /// </summary>
        /// <param name="id">Guid of the contact that should be deleted</param>
        /// <returns>Returns Ok or Not found</returns>
        /// <response code="200">Success</response>
        /// <response code="404">If contact is not found</response>
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteContactAsync(Guid id)
        {
            var contactIsDeleted = await _contactService.DeleteContactAsync(id);

            if (contactIsDeleted)
            {
                return Ok();
            }

            return NotFound();
        }

        /// <summary>
        /// Updates the contact by the id
        /// </summary>
        /// <param name="updateModel">Contact that should be updated</param>
        /// <remarks>Update model should contain the real guid of the contact that should be updated</remarks>
        /// <returns>Returns Ok or Not found</returns>
        /// <response code="200">Success</response>
        /// <response code="404">If contact is not found</response>
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateContactAsync(UpdateContactModel updateModel)
        {
            var contactIsFound = await _contactService.UpdateContactAsync(_mapper.Map<Contact>(updateModel));

            if (contactIsFound)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
