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
            var item = new ProductModel { Price = 10, ProductId = 1234 };
            //var basket = new BasketModel { Products = new List<ProductModel>()};
            var customer = new UserModel { Name = "customerName", EmailAddress = "test@test.com", Password = "password", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 10, BasketId = 1};

            //Act
            var userRepository = new UserRepository(DataLocation);
            var customerFromJson = userRepository.GetUserByName(customer.Name);
            //var basketRepository = new BasketRepository;
            //basketRepository.AddItem(customerFromJson.UserId, item.ProductId);

            //Assert
            Assert.AreEqual(customer.Name, customerFromJson.Name);
            Assert.AreEqual(customer.EmailAddress, customerFromJson.EmailAddress);
            Assert.AreEqual(customer.Password, customerFromJson.Password);
            Assert.AreEqual(customer.LoyaltyLevel, customerFromJson.LoyaltyLevel);
            Assert.AreEqual(customer.YearlySpend, customerFromJson.YearlySpend);
        }
    }
}
