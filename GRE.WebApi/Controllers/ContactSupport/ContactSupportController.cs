using GRE.Application.Interfaces.Services.ContactSupport;
using GRE.Shared.DTOs.ContactSupport;
using GRE.Shared.DTOs.Newsletter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GRE.WebApi.Controllers.ContactSupport
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactSupportController : ControllerBase
    {
        private IContactSupportService _contactSupportService;
        public ContactSupportController(IContactSupportService contactSupportService)
        {
            _contactSupportService = contactSupportService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddContactSupport([FromBody] ContactSupportDto contactSupportDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _contactSupportService.CreateContactSupportAsync(contactSupportDto));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateContactSupport([FromBody] ContactSupportDto contactSupportDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _contactSupportService.UpdateContactSupportAsync(contactSupportDto));
        }
    }
}
