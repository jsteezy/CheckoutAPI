using NUnit.Framework;
using StrataTest.Commands;
using StrataTest.Domain;
using StrataTest.Enums;
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
            var item = new ProductCommand { Price = 10, ProductId = 1234 };
            //var basket = new BasketCommand { Products = new List<ProductCommand>()};
            var customer = new UserModel { UserName = "customerName", Email = "test@test.com", PasswordHash = "password", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 10, BasketId = 1};

            //Act
            var userRepository = new UserRepository(DataLocation);
            var customerFromJson = userRepository.GetUserByName(customer.UserName);
            //var basketRepository = new BasketRepository;
            //basketRepository.AddItem(customerFromJson.UserId, item.ProductId);

            //Assert
            Assert.AreEqual(customer.UserName, customerFromJson.UserName);
            Assert.AreEqual(customer.Email, customerFromJson.Email);
            Assert.AreEqual(customer.PasswordHash, customerFromJson.PasswordHash);
            Assert.AreEqual(customer.LoyaltyLevel, customerFromJson.LoyaltyLevel);
            Assert.AreEqual(customer.YearlySpend, customerFromJson.YearlySpend);
        }
    }
}
