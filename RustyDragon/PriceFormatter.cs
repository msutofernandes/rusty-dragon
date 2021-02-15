using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RustyDragon
{
    public class PriceFormatter
    {
        public static double ShowPriceAsDecimal(double price)
        {
            return Math.Round(price, 2, MidpointRounding.AwayFromZero);
        }

        public static string ShowPriceAsDecimalWithDollarSign(double price)
        {
            return Math.Round(price, 2, MidpointRounding.AwayFromZero).ToString("C", CultureInfo.CurrentCulture);
        }

        public static string ShowPriceAsGoldAndSilver(double price)
        {
            string stringPrice = price.ToString("0.00", CultureInfo.InvariantCulture);
            string[] parts = stringPrice.Split('.');
            string gold = parts[0];
            string silver = parts[1];

            return String.Format("{0} gold pieces, {1} silver pieces", gold.ToString(), silver.ToString());
        }
    }
}
