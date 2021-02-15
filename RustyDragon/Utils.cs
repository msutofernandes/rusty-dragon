using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RustyDragon
{
    public class Utils
    {
        public const string XML_PATH = @"C:\temp\rustydragon\";
        public static DateTime ReceivedDate { get; set; }

        public static List<Cheese> ReadXMLFile()
        {
            List<Cheese> cheeses = new List<Cheese>();
            var cheeseList = new CheeseList();
            var filePath = GetFilePath();

            if (!String.IsNullOrEmpty(filePath))
            {
                cheeseList = SerializeXML(filePath);
                Utils.ReceivedDate = DateTime.ParseExact(filePath.Substring(filePath.Length - 12, 8), "ddMMyyyy", CultureInfo.InvariantCulture);
            }            

            foreach (var cheese in cheeseList.Cheese)
            {
                cheeses.Add(CheeseFactory.GetCheese(cheese.Name, cheese.SerializedDate, cheese.DaysToSell, cheese.Price, cheese.Type, Utils.ReceivedDate));
            }

            return cheeses;
        }

        static CheeseList SerializeXML(string filePath)
        {
            var serializer = new XmlSerializer(typeof(CheeseList), new XmlRootAttribute("Items"));
            var reader = new StreamReader(filePath);

            return (CheeseList)serializer.Deserialize(reader);
        }

        static string GetFilePath()
        {
            IEnumerable<string> files = Directory.EnumerateFiles(XML_PATH, "*.xml");
            return files.FirstOrDefault();
        }

        public static void ShowCheeseInventoryPricing(List<Cheese> cheeseList, DateTime dateReceived, int numberOfDays)
        {
            for (int i = 0; i < numberOfDays; i++)
            {
                Console.WriteLine("Pricing on {0}", dateReceived.Date.ToString("MMMM dd, yyyy"));

                foreach (var item in cheeseList)
                {
                    item.SetPrice(item, dateReceived);
                    Console.WriteLine("{0, -18} - {1, 7}", item.Name, item.IsExpired(dateReceived) ? "Cheese has expired" : PriceFormatter.ShowPriceAsDecimal(item.Price));
                }
                Console.WriteLine();
                dateReceived = dateReceived.AddDays(1);
            }
        }

        public static bool PastBeforeDate(Cheese cheese, DateTime currentDate)
        {
            var bestBeforeDate = cheese.BestBeforeDate.HasValue ? (DateTime?)cheese.BestBeforeDate.Value.Date : null;
            return currentDate > bestBeforeDate;
        }

        public static int DaysRemainingBeforeExpiration(Cheese cheese, DateTime currentDate)
        {
            var bestBeforeDate = cheese.BestBeforeDate.HasValue ? (DateTime?)cheese.BestBeforeDate.Value.Date : null;
            return (bestBeforeDate.Value.Date - currentDate).Days;
        }
    }
}
