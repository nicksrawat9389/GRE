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

        public DateTime DateAdded { get; set; }

        public DateTime DateLastUpdated { get; set; }
    }
}
