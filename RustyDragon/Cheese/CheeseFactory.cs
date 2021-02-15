using System;
using System.Collections.Generic;
using System.Text;

namespace RustyDragon
{
    class CheeseFactory
    {
        public static Cheese GetCheese(string name, string serializedDate, string daysToSell, double price, CheeseType.Name type, DateTime receivedDate)
        {
            switch (type)
            {
                case CheeseType.Name.Standard:
                    return new Standard(name, serializedDate, daysToSell, price, type, receivedDate);
                case CheeseType.Name.Aged:
                    return new Aged(name, serializedDate, daysToSell, price, type, receivedDate);
                case CheeseType.Name.Fresh:
                    return new Fresh(name, serializedDate, daysToSell, price, type, receivedDate);
                case CheeseType.Name.Unique:
                    return new Unique(name, serializedDate, daysToSell, price, type, receivedDate);
                case CheeseType.Name.Special:
                    return new Special(name, serializedDate, daysToSell, price, type, receivedDate);
                default:
                    break;
            }

            throw new ArgumentException("Type does not exist");
        }
    }
}
