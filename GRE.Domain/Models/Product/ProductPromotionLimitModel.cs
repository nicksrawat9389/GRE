using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Domain.Models.Product
{
    public class ProductPromotionLimitModel
    {
        public int LimitId { get; set; }

        public int ProductId { get; set; }

        public int MinQuantity { get; set; }

        public int MaxQuantity { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public DateTime DateAdded { get; set; }

        public DateTime DateLastUpdated { get; set; }
    }
}

