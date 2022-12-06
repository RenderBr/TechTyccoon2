using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.Products;

namespace TechTyccoon2
{
    public class ProductsManager
    {
        public List<Product> ReleasedProducts = new List<Product>();

        public List<Product> GetProducable(ICompanyType type)
        {
            return Products.Types.ProductTypes.
        }

        public void CreateProduct(Company company)
        {
            Product product;
            Random r = new Random();

            List<Product> canMake = GetProducable(company.Industry);

            IProductType Industry = canMake[r.Next(0, canMake.Count - 1)];

            product = new Product()
        }

        public void ReleaseProduct()
        {

        }

        public void FurtherProduct()
        {

        }

        public void ApplySales()
        {

        }

        public void GetStats()
        {

        }
    }
}
