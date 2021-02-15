using System;
using System.Collections.Generic;
using System.Text;

namespace RustyDragon
{
    public class Standard : Cheese
    {
        public Standard(string name, string serializedDate, string daysToSell, double price, CheeseType.Name type, DateTime receivedDate) : base(name, serializedDate, daysToSell, price, type, receivedDate)
        {
        }
    }
}
