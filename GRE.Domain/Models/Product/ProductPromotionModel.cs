using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Domain.Models.Product
{
    public class ProductPromotionModel
    {
        public int PromotionId { get; set; }

        public int ProductId { get; set; }

        public DateTime PromoStartDate { get; set; }

        public DateTime PromoEndDate { get; set; }

        public string PromoDetails { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public DateTime DateAdded { get; set; }

        public DateTime DateLastUpdated { get; set; }
    }
}
