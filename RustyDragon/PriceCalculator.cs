using System;
using System.Collections.Generic;
using System.Text;

namespace RustyDragon
{
    public class PriceCalculator
    {
        public static double ApplyAddition(Cheese cheese, DateTime currentDate)
        {
            var percentage = cheese.PercentageDiscount(cheese, currentDate);
            var newPrice = cheese.Price += (cheese.Price * percentage / 100f);

            if (cheese.ReachMax())
            {
                return 20;
            }

            return newPrice;
        }

        public static double ApplyDiscount(Cheese cheese, DateTime currentDate)
        {
            var percentage = cheese.PercentageDiscount(cheese, currentDate);
            var newPrice = cheese.Price -= (cheese.Price * percentage / 100f);

            if (cheese.ReachMin())
            {
                return 0;
            }

            return newPrice;
        }
    }
}
