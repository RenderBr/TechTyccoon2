using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.Products.ProductTypes;

namespace TechTyccoon2.Products
{
    public static class Types
    {
        public enum productTypes
        {
            VideoGames = 1
        }

        public static List<IProductType> ProductTypes = new List<IProductType>()
        {
            new VideoGame()
        };


        public static IProductType Product(productTypes type)
        {
            switch (type)
            {
                case productTypes.VideoGames:
                    return ProductTypes.First(x => x.Name == "Video Game");
                default:
                    return null;
            }
        }
    }

}
