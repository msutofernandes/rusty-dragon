using System;
using System.Collections.Generic;
using System.Text;

namespace RustyDragon
{
    public class Special : Cheese
    {
        public Special(string name, string serializedDate, string daysToSell, double price, CheeseType.Name type, DateTime receivedDate) : base(name, serializedDate, daysToSell, price, type, receivedDate)
        {
        }

        public override void SetPrice(Cheese cheese, DateTime currentDate)
        {

            if (Utils.DaysRemainingBeforeExpiration(cheese, currentDate) > 10)
            {
                cheese.Price = PriceCalculator.ApplyDiscount(cheese, currentDate);
            }
            else if (Utils.DaysRemainingBeforeExpiration(cheese, currentDate) <= 5)
            {
                cheese.Price = PriceCalculator.ApplyAddition(cheese, currentDate);
            }
            else
            {
                cheese.Price = PriceCalculator.ApplyAddition(cheese, currentDate);
            }
        }

        public override int PercentageDiscount(Cheese cheese, DateTime currentDate)
        {
            if (Utils.DaysRemainingBeforeExpiration(cheese, currentDate) > 10)
            {
                return 5;
            }
            else if (Utils.DaysRemainingBeforeExpiration(cheese, currentDate) <= 5)
            {
                return 10;
            }

            return 5;
        }
    }
}
