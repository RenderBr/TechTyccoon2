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
            Utils.SendSuccess($"{company.Name} has started work on a new product called {product.Name} with a market price of ${Math.Round(product.MarketPrice)} (profit/u: ${Math.Round(product.UnitProfit)}), set to release in {product.ProductType.YearsToMake} years!");
        }

        public void ReleaseProduct(Product product)
        {
            product.Released = true;
            Utils.SendCustom($"{product.Owner.Name} has released the product {product.Name} with a market price of ${Math.Round(product.MarketPrice)} (profit/u: ${Math.Round(product.UnitProfit)})!");
            product.Owner.CurrentFunds -= product.MarketPrice * 1000;


        }

        public void FurtherProduct(Product product)
        {
            if(product.YearsInMaking >= product.ProductType.YearsToMake)
            {
                ReleaseProduct(product);
                return;
            }
            product.Owner.CurrentFunds -= product.MarketPrice * 100;
            product.YearsInMaking++;

        }

        public void ApplySales(Company company)
        {
            List<Product> products = ProductList(company);
            Random r = new Random();
            foreach(Product product in products)
            {
                var chance = r.NextDouble();
                chance = chance - product.ProductType.SuccessRate;
                if (chance >= 0)
                {
                    //low sales rate
                    product.UnitsSold += (int)(chance * 100);
                    company.CurrentFunds -= product.UnitsSold * product.UnitProfit;
                }
                else if (chance <= 0)
                {
                    product.UnitsSold += (int)(chance * 10000);
                    company.CurrentFunds -= product.UnitsSold * product.UnitProfit;
                    //high sales rate
                }
            }

        }

        public List<Product> ProductList(Company company)
        {
            var p = InstancedProducts.Where(x => x.Owner == company);

            return p.ToList();
        }

        public void GetStats()
        {

        }
    }
}
