using GRE.Application.Interfaces.Services.Newsletter;
using GRE.Shared.DTOs.Newsletter;
using GRE.Shared.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GRE.WebApi.Controllers.Newsletter
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewsLetter([FromBody] NewsletterDto newsletter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _newsletterService.AddNewsLetterAsync(newsletter));
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateNewsLetter([FromBody] NewsletterDto newsletter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _newsletterService.UpdateNewsLetterAsync(newsletter));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteNewsLetter([FromBody] int newsletterId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _newsletterService.DeleteNewsLetterAsync(newsletterId));
        }

    }
}
