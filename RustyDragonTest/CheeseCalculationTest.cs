using System;
using System.Globalization;
using RustyDragon;
using Xunit;

namespace RustyDragonTest
{
    public class CheeseCalculationTest
    {
        [Fact]
        public void StandardCheesePriceShouldDecrease()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            var cheese = new Standard("Cheddar", "2021-02-18", "10", 3.87, CheeseType.Name.Standard, Utils.ReceivedDate);

            for (int i = 0; i < 6; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.Equal(2.55, PriceFormatter.ShowPriceAsDecimal(cheese.Price));
        }

        [Fact]
        public void StandardCheeseShouldExpire()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Standard("Cheddar", "2021-02-15", "3", 3.87, CheeseType.Name.Standard, Utils.ReceivedDate);

            for (int i = 0; i <= 7; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.True(cheese.IsExpired(currentDate));
            Assert.Equal(0, PriceFormatter.ShowPriceAsDecimal(cheese.Price));
        }

        [Fact]
        public void AgedCheesePriceShouldIncrease()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Aged("Roquefort", "2021-02-20", "8", 14.25, CheeseType.Name.Aged, Utils.ReceivedDate);

            for (int i = 0; i < 3; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.Equal(16.50, PriceFormatter.ShowPriceAsDecimal(cheese.Price));
        }

        [Fact]
        public void AgedCheeseShouldExpire()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Aged("Roquefort", "2021-02-20", "3", 14.25, CheeseType.Name.Aged, Utils.ReceivedDate);

            for (int i = 0; i <= 4; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.True(cheese.IsExpired(currentDate));
        }

        [Fact]
        public void UniqueCheesePriceShouldNotChange()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Unique("Calcagno", null, null, 18.90, CheeseType.Name.Unique, Utils.ReceivedDate);

            for (int i = 0; i <= 5; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.Equal(18.90, PriceFormatter.ShowPriceAsDecimal(cheese.Price));
        }

        [Fact]
        public void UniqueCheeseShouldNotExpire()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Unique("Calcagno", null, null, 18.90, CheeseType.Name.Unique, Utils.ReceivedDate);

            for (int i = 0; i <= 4; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.False(cheese.IsExpired(currentDate));
        }

        [Fact]
        public void FreshCheesePriceShouldDecreaseAtTwiceTheRateOfStandarCheese()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Fresh("Queso Fresco", "2021-02-14", "4", 2.21, CheeseType.Name.Fresh, Utils.ReceivedDate);

            for (int i = 0; i < 2; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.Equal(1.41, PriceFormatter.ShowPriceAsDecimal(cheese.Price));
        }

        [Fact]
        public void FreshCheesePriceShouldExpire()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Fresh("Queso Fresco", "2021-02-14", "2", 2.21, CheeseType.Name.Fresh, Utils.ReceivedDate);

            for (int i = 0; i <= 3; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.True(cheese.IsExpired(currentDate));
        }

        [Fact]
        public void SpecialCheesePriceShouldDecreaseUntil10DaysBeforeExpiration()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Special("Dragon Mozzarella", "2021-02-28", "10", 2.21, CheeseType.Name.Special, Utils.ReceivedDate);

            for (int i = 0; i < 6; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.Equal(2.19, PriceFormatter.ShowPriceAsDecimal(cheese.Price));
        }

        [Fact]
        public void SpecialCheesePriceShouldIncreaseAfter10Days()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Special("Dragon Mozzarella", "2021-02-28", "10", 2.21, CheeseType.Name.Special, Utils.ReceivedDate);

            for (int i = 0; i < 10; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.Equal(2.93, PriceFormatter.ShowPriceAsDecimal(cheese.Price));
        }

        [Fact]
        public void CheesePriceShouldNotBeMoreThan20()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Aged("Roquefort", "2021-02-20", "10", 14.25, CheeseType.Name.Aged, Utils.ReceivedDate);

            for (int i = 0; i < 8; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.Equal(20, PriceFormatter.ShowPriceAsDecimal(cheese.Price));
        }

        [Fact]
        public void CheesePriceShouldNotBeLessThan0()
        {
            Utils.ReceivedDate = new DateTime(2021, 02, 15);
            var currentDate = Utils.ReceivedDate;
            Cheese cheese = new Fresh("Queso Fresco", "2021-02-14", "10", 1.10, CheeseType.Name.Fresh, Utils.ReceivedDate);

            for (int i = 0; i <= 14; i++)
            {
                cheese.SetPrice(cheese, currentDate);
                currentDate = currentDate.AddDays(1);
            }

            Assert.Equal(0, PriceFormatter.ShowPriceAsDecimal(cheese.Price));
        }

        [Fact]
        public void CheesePriceShouldBeRounded()
        {
            Cheese cheese = new Cheese();
            Cheese cheese2 = new Cheese();
            cheese.Price = 3.624;
            cheese2.Price = 3.625;

            cheese.Price = Math.Round(cheese.Price, 2, MidpointRounding.AwayFromZero);
            cheese2.Price = Math.Round(cheese2.Price, 2, MidpointRounding.AwayFromZero);

            Assert.Equal(3.62, PriceFormatter.ShowPriceAsDecimal(cheese.Price));
            Assert.Equal(3.63, cheese2.Price);
        }
    }
}
