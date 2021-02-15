using System;
using System.Collections.Generic;
using System.Text;

namespace RustyDragon
{
    public class Unique : Cheese
    {
        public Unique(string name, string serializedDate, string daysToSell, double price, CheeseType.Name type, DateTime receivedDate) : base(name, serializedDate, daysToSell, price, type, receivedDate)
        {
        }

        public override bool IsExpired(DateTime currentDate)
        {
            return false;
        }

        public override void SetPrice(Cheese cheese, DateTime currentDate)
        {
            cheese.Price = cheese.Price;
        }
    }
}
