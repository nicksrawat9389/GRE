using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.DTOs.Newsletter
{
    public class NewsletterDto
    {
        public int NewsletterId { get; set; }
        public string Title { get; set; }
        public string PdfName { get; set; }
        public string PdfBase64 { get; set; }
        public DateTime PublishedDate { get; set; }

    }
}
