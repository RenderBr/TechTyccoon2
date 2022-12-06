using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2
{
    public interface IProductType
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICompanyType Industry { get; set; }

        public double SuccessRate { get; set; } // 0.01-1 (determines if product will succeed or not)

        public int Popularity { get; set; } // 1 - 100 (determines scaling of product sales)

        public int YearsToMake { get; set; } // how long will this product type take to make?
    }
}
