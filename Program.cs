using System;
using System.Security.Principal;
using TechTyccoon2;
using TechTyccoon2.CompanyTypes;

namespace TechTycoon2;
class Program
{
    static void Main(string[] args)
    {
        Console.Title= $"Tech Tycoon 2 - Alpha {GameManager.Version} - created by RenderBr";
        GameManager.InitializeGame(false);
    }
}