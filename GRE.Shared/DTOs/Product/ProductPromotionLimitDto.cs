using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.DTOs.Product
{
    public class ProductPromotionLimitDto
    {
        public int LimitId { get; set; }

        public int ProductId { get; set; }

        public int MinQuantity { get; set; }

        public int MaxQuantity { get; set; }

    }
}
