using System;
using System.Collections.Generic;
using System.Text;

namespace RustyDragon
{
    public class Aged : Cheese
    {
        public Aged(string name, string serializedDate, string daysToSell, double price, CheeseType.Name type, DateTime receivedDate) : base(name, serializedDate, daysToSell, price, type, receivedDate)
        {
        }

        public override void SetPrice(Cheese cheese, DateTime currentDate)
        {
            cheese.Price = PriceCalculator.ApplyAddition(cheese, currentDate);
        }
    }
}
