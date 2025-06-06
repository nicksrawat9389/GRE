using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Domain.Models.Newsletter
{
    public class NewsletterModel
    {
        public int NewsletterId { get; set; }
        public string Title { get; set; }
        public string PdfName { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateLastUpdated { get; set; }
    }
}
