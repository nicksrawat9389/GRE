using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.DTOs.Product
{
    public class ProductDto
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public string Description { get; set; }

        public int UnitsPerCase { get; set; } 

        public string UnitType { get; set; }
        public decimal RetailerPrice { get; set; }
        public decimal DistributorPrice { get; set; }
    }
}
