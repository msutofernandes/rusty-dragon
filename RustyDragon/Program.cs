using System;
using System.Collections.Generic;

namespace RustyDragon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cheese> cheeses = Utils.ReadXMLFile();
            Utils.ShowCheeseInventoryPricing(cheeses, Utils.ReceivedDate, 7);
            Console.ReadKey();
        }
    }
}
