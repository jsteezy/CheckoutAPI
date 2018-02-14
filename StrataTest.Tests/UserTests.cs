using NUnit.Framework;
using StrataTest.Commands;
using StrataTest.Enums;
using StrataTest.Repository;

namespace StrataTest.Tests
{
    [TestFixture]
    public class UserTests
    {


        [Test]
        public void LoadUserDataFromStorage()
        {
            //Arrange
            var customer = new UserCommand { UserName = "customerName", Email = "test@test.com", Password = "password", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 10};

            //Act
            var userRepository = new UserRepository();
            var customerResult = userRepository.GetUserByName(customer.UserName).Result;

            //Assert
            Assert.AreEqual(customer.UserName, customerResult.UserName);
            Assert.AreEqual(customer.Email, customerResult.Email);
            Assert.AreEqual(customer.Password, customerResult.PasswordHash);
            Assert.AreEqual(customer.LoyaltyLevel, customerResult.LoyaltyLevel);
            Assert.AreEqual(customer.YearlySpend, customerResult.YearlySpend);
        }

        [Test]
        public void AddUserToStorage()
        {
            //Arrange
            var newCustomer = new UserCommand { UserName = "customerName1", Email = "test1@test.com", Password = "password1", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 0 };

            //Act
            var userRepository = new UserRepository();
            var customerResult = userRepository.GetUserByName(newCustomer.UserName).Result;


            //Assert
            Assert.AreEqual(newCustomer.UserName, customerResult.UserName);
            Assert.AreEqual(newCustomer.Email, customerResult.Email);
            Assert.AreEqual(newCustomer.Password, customerResult.PasswordHash);
            Assert.AreEqual(newCustomer.LoyaltyLevel, customerResult.LoyaltyLevel);
            Assert.AreEqual(newCustomer.YearlySpend, customerResult.YearlySpend);

        }

        [Test]
        public void AuthenticateUserWithCorrectPassword()
        {
            //Arrange
            var customer = new UserCommand { UserName = "customerName", Email = "test@test.com", Password = "password", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 10 };

            //Act
            var repo = new UserRepository();
            var result = repo.Authenticate(customer.Email, customer.Password);

            //Assert
           // Assert.True(result);
        }

        [Test]
        public void DoNotAuthenticateUserWithIncorrectPassword()
        {
            //Arrange
            var customer = new UserCommand { UserName = "customerName", Email = "test@test.com", Password = "badPassword", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 10 };

            //Act
            var repo = new UserRepository();
            var result = repo.Authenticate(customer.Email, customer.Password);

            //Assert
            //Assert.Fail(result);
        }
    }
}
