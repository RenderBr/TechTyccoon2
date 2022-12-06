using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.Products;
using TechTyccoon2.Utilities;

namespace TechTyccoon2
{
    public class ProductsManager
    {
        public List<Product> InstancedProducts = new List<Product>();

        public List<IProductType> GetProducable(ICompanyType type)
        {
            return Products.Types.ProductTypes.FindAll(x => x.Industry == type);
        }

        public void CreateProduct(Company company)
        {
            Product product;
            Random r = new Random();

            List<IProductType> canMake = GetProducable(company.Industry);

            if(canMake.Count <= 0) {
                return;
            }

            IProductType Industry = canMake[r.Next(0, canMake.Count - 1)];

            product = new Product(Industry.Name, Industry.Description, Industry, company, company, Industry.MedianPrice + (r.Next(-10 * (int)(Math.Round(Industry.MedianPrice * 0.08)), 10 * (int)(Math.Round(Industry.MedianPrice * 0.08)))));
            InstancedProducts.Add(product);
            Utils.SendSuccess($"{company.Name} has started work on a new product called {product.Name} with a market price of ${product.MarketPrice} (profit/u: ${product.UnitProfit}), set to release in {product.ProductType.YearsToMake} years!");
        }

        public void ReleaseProduct(Product product)
        {
            product.Released = true;
            Utils.SendCustom($"{product.Owner.Name} has released the product {product.Name} with a market price of ${Math.Round(product.MarketPrice)} (profit/u: ${Math.Round(product.UnitProfit)})!");

        }

        public void FurtherProduct(Product product)
        {
            if(product.YearsInMaking >= product.ProductType.YearsToMake)
            {
                ReleaseProduct(product);
                return;
            }
            product.YearsInMaking++;

        }

        public void ApplySales()
        {

        }

        public void GetStats()
        {

        }
    }
}
