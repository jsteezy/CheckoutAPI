using System.Collections.Generic;
using NUnit.Framework;
using StrataTest.Models;
using StrataTest.Repository;

namespace StrataTest.Tests
{
    [TestFixture]
    public class BasketTests
    {
        //change to relative or other data store
        private const string DataLocation = "C:/Users/j.stevens/source/repos/StrataTest/StrataTest.Tests/TestData/BasketData.json";


        [Test]
        public void AddItemToBasket()
        {
            //Arrange
            var item = new Product { Price = 10, ProductId = 1234 };
            //var basket = new Basket { Products = new List<Product>()};
            var customer = new User { Name = "customerName", EmailAddress = "test@test.com", Password = "password", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 10, Basket = basket};

            //Act
            var repo = new UserRepository(DataLocation);
            var customerFromJson = repo.GetUserByName(customer.Name);
            var basket = customerFromJson.Basket; // .AddItem(item);
            basket.AddItem(item);

            //Assert
            Assert.AreEqual(customer.Name, customerFromJson.Name);
            Assert.AreEqual(customer.EmailAddress, customerFromJson.EmailAddress);
            Assert.AreEqual(customer.Password, customerFromJson.Password);
            Assert.AreEqual(customer.LoyaltyLevel, customerFromJson.LoyaltyLevel);
            Assert.AreEqual(customer.YearlySpend, customerFromJson.YearlySpend);
        }
    }
}
