using System;
using System.Collections.Generic;
using System.Text;

namespace RustyDragon
{
    public class Fresh : Cheese
    {
        public Fresh(string name, string serializedDate, string daysToSell, double price, CheeseType.Name type, DateTime receivedDate) : base(name, serializedDate, daysToSell, price, type, receivedDate)
        {
        }

        public override void SetPrice(Cheese cheese, DateTime currentDate)
        {
            if (!IsExpired(currentDate))
            {
                cheese.Price = PriceCalculator.ApplyDiscount(cheese, currentDate);
            }
        }

        public override int PercentageDiscount(Cheese cheese, DateTime currentDate)
        {
            if (Utils.PastBeforeDate(cheese, currentDate))
            {
                return 10 * 2;
            }

            return 5 * 2;
        }
    }
}
