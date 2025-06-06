using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.DTOs.Product
{
    public class ProductPromotionDto
    {
        public int PromotionId { get; set; }

        public int ProductId { get; set; }

        public DateTime PromoStartDate { get; set; }

        public DateTime PromoEndDate { get; set; }

        public string PromoDetails { get; set; }
    }
}
