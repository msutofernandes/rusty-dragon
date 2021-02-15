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

            return cheese.Price += (cheese.Price * percentage / 100f);
        }

        public static double ApplyDiscount(Cheese cheese, DateTime currentDate)
        {
            var percentage = cheese.PercentageDiscount(cheese, currentDate);

            return cheese.Price -= (cheese.Price * percentage / 100f);
        }
    }
}
