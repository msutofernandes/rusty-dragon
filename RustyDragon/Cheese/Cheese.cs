using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RustyDragon
{
    public class Cheese
    {
        public Cheese() { }

        public Cheese(string name, string serializedDate, string daysToSell, double price, CheeseType.Name type, DateTime receivedDate)
        {
            Name = name;
            BestBeforeDate = null;
            SerializedDate = serializedDate;
            DaysToSell = daysToSell;
            Price = price;
            Type = type;
            ReceivedDate = receivedDate;
        }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlIgnore]
        public DateTime? BestBeforeDate
        {
            get
            {
                if (DateTime.TryParse(SerializedDate, out DateTime dt))
                {
                    return dt;
                }

                return null;
            }
            set
            {
                SerializedDate = (value == null) ? (string)null : value.Value.ToString("yyyy-MM-ddTHH:mm:ss");
            }
        }

        [XmlElement(ElementName = "BestBeforeDate")]
        public string SerializedDate { get; set; }

        [XmlElement(ElementName = "DaysToSell", IsNullable = true)]
        public string DaysToSell { get; set; }

        [XmlElement(ElementName = "Price")]
        public double Price { get; set; }

        [XmlElement(ElementName = "Type")]
        public CheeseType.Name Type { get; set; }

        public DateTime ReceivedDate { get; set; }

        public virtual void SetPrice(Cheese cheese, DateTime currentDate)
        {
            if (!IsExpired(currentDate))
            {
                cheese.Price = PriceCalculator.ApplyDiscount(cheese, currentDate);
            }
        }

        public virtual bool IsExpired(DateTime currentDate)
        {
            if ((currentDate - this.ReceivedDate).Days > Int32.Parse(this.DaysToSell))
            {
                Price = 0;
                return true;                
            }

            return false;
        }

        public virtual int PercentageDiscount(Cheese cheese, DateTime currentDate)
        {
            if (Utils.PastBeforeDate(cheese, currentDate))
            {
                return 10;
            }

            return 5;
        }

        public bool ReachMin()
        {
            if (Price < 0)
            {
                return true;
            }

            return false;
        }

        public bool ReachMax()
        {
            if (Price > 20)
            {
                return true;
            }

            return false;
        }
    }
}
