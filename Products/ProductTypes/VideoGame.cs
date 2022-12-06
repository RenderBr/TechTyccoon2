using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2;
using TechTyccoon2.Providers;

namespace TechTyccoon2.Products.ProductTypes
{
    public class VideoGame : IProductType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICompanyType Industry { get; set; }
        public double SuccessRate { get; set; }

        public double MedianPrice { get; set; }
        public int Popularity { get; set; }
        public int YearsToMake { get; set; }

        public VideoGame()
        {
            Random r = new Random();
            Name = "Video Game";
            Description = "An electronic game played on a computer or video game console.";
            Industry = Companies.Industry(Companies.Types.Tech);
            SuccessRate = r.NextDouble()-0.2;
            Popularity = 45;
            YearsToMake = 3;
            MedianPrice = 45;
        }
    }
}
