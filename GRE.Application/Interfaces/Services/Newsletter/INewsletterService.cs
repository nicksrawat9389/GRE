using GRE.Shared.DTOs.Newsletter;
using GRE.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Application.Interfaces.Services.Newsletter
{
    public interface INewsletterService
    {
        Task<JsonModel> AddNewsLetterAsync(NewsletterDto newsletterDto);
        Task<JsonModel> UpdateNewsLetterAsync(NewsletterDto newsletterDto);
        Task<JsonModel> DeleteNewsLetterAsync(int newsletterId);
    }
}
