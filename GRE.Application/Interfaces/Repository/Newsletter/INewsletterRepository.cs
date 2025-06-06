using GRE.Domain.Models.Newsletter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Application.Interfaces.Repository.Newsletter
{
    public interface INewsletterRepository
    {
        Task<bool> CreateNewsLetter(NewsletterModel newsletter);
        Task<bool> UpdateNewsLetter(NewsletterModel newsletter);
        Task<bool> NewsletterExist(int newsletterId);
        Task<bool> DeleteNewsletter(int newsletterId);
    }
}
