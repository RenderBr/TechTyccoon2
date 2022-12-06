using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TechTyccoon2.Utilities
{
    public static class Slogans
    {
        public static List<string> SloganList = new List<string>()
        {
            "We aim to please",
            "With us, it's easy!",
            "Get things done",
            "You'll love us!",
            "We're too good at what we do!",
            "#BLESSED BB",
            "There's nobody better!",
            "So good it should be illegal.",
            "We're changing things.",
            "The definition of innovative"


        };

        public static string RandomMotto()
        {
            Random r= new Random();
            string slogan = SloganList[r.Next(0,SloganList.Count())];
            return slogan;
        }

    }
}
