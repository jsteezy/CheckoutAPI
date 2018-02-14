using Moq;
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
        private Mock<UserRepository> _userRepoMock;

        [SetUp]
        public void Setup()
        {
            _userRepoMock = new Mock<UserRepository>();

        }

        [Test]
        public void AddItemToBasket()
        {
            //Arrange
            var item = new ProductCommand { Price = 10, ProductId = 1234 };
            //var basket = new BasketCommand { Products = new List<ProductCommand>()};
            var customer = new UserModel { UserName = "customerName", Email = "test@test.com", PasswordHash = "password", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 10, BasketId = 1 };

            //Act
            var userRepository = new UserRepository();
            var customerResult = userRepository.GetUserByName(customer.UserName).Result;
            //var basketRepository = new BasketRepository;
            //basketRepository.AddItem(customerFromJson.UserId, item.ProductId);

            //Assert
            Assert.AreEqual(customer.UserName, customerResult.UserName);
            Assert.AreEqual(customer.Email, customerResult.Email);
            Assert.AreEqual(customer.PasswordHash, customerResult.PasswordHash);
            Assert.AreEqual(customer.LoyaltyLevel, customerResult.LoyaltyLevel);
            Assert.AreEqual(customer.YearlySpend, customerResult.YearlySpend);
        }
    }
}
