using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2;
using TechTyccoon2.Products.ProductTypes;

namespace TechTyccoon2.Products
{
    public class Product
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IProductType ProductType { get; set; }

        public Company Owner { get; set; } // can change, companies will be able to sell products, will initially be creator

        public Company Creator { get; set; } // initial creator

        public double MarketPrice { get; set; }

        public double CostPerUnit { get; set; }

        public double UnitProfit { get { return MarketPrice-CostPerUnit; } set { } } /*finds profit by taking the market price (which should be higher than costperunit, 
                                                                                      * and taking it away to find total profits of each product sold */

        public int UnitsSold { get; set; } = 0;

        public bool Released { get; set; } = false;

        public int YearReleased { get; set; }

        public int YearsInMaking { get; set; }
        
    }
}
