using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Domain.Models.Product
{
    public class ProductModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public int UnitsPerCase { get; set; } 

        public string UnitType { get; set; }

        public decimal RetailerPrice { get; set; }
        public decimal DistributorPrice { get; set; }
        public decimal ProductPrice { get; set; }


        public DateTime DateAdded { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public ProductPromotionModel ProductPromotion { get; set; }
        public ProductPromotionLimitModel ProductPromotionLimit { get; set; }
    }

    public class ProductListing : ProductModel
    {
        public int PromotionId { get; set; }
        public DateTime PromoStartDate { get; set; }

        public DateTime PromoEndDate { get; set; }

        public string PromoDetails { get; set; }
        public int LimitId { get; set; }

        public int MinQuantity { get; set; }

        public int MaxQuantity { get; set; }

        public int TotalRecords { get; set; }
    }
}