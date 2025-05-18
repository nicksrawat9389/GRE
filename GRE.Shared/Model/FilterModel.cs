using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.Model
{
    public class FilterModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string ProductType { get; set; }
        public string UserClassification { get; set; }
    }
}
