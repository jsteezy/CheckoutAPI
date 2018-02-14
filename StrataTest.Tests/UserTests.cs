using NUnit.Framework;
using StrataTest.Commands;
using StrataTest.Enums;
using StrataTest.Repository;

namespace StrataTest.Tests
{
    [TestFixture]
    public class UserTests
    {
        //change to relative or other data store
        private const string DataLocation = "C:/Users/j.stevens/source/repos/StrataTest/StrataTest.Tests/TestData/UserData.json";


        [Test]
        public void LoadUserDataFromStorage()
        {
            //Arrange
            var customer = new UserCommand { UserName = "customerName", Email = "test@test.com", Password = "password", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 10};

           //Act
           var repo = new UserRepository(DataLocation);
            var customerFromJson = repo.GetUserByName(customer.UserName);

            //Assert
            Assert.AreEqual(customer.UserName, customerFromJson.UserName);
            Assert.AreEqual(customer.Email, customerFromJson.Email);
            Assert.AreEqual(customer.Password, customerFromJson.PasswordHash);
            Assert.AreEqual(customer.LoyaltyLevel, customerFromJson.LoyaltyLevel);
            Assert.AreEqual(customer.YearlySpend, customerFromJson.YearlySpend);
        }

        [Test]
        public void AddUserToStorage()
        {
            //Arrange
            var newCustomer = new UserCommand { UserName = "customerName1", Email = "test1@test.com", Password = "password1", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 0 };

            //Act
            var repo = new UserRepository(DataLocation);
           // repo.AddUser(newCustomer);

            //Assert
            var customerFromJson = repo.GetUserByName(newCustomer.UserName);
            Assert.AreEqual(newCustomer.UserName, customerFromJson.UserName);
            Assert.AreEqual(newCustomer.Email, customerFromJson.Email);
            Assert.AreEqual(newCustomer.Password, customerFromJson.PasswordHash);
            Assert.AreEqual(newCustomer.LoyaltyLevel, customerFromJson.LoyaltyLevel);
            Assert.AreEqual(newCustomer.YearlySpend, customerFromJson.YearlySpend);

        }

        [Test]
        public void AuthenticateUserWithCorrectPassword()
        {
            //Arrange
            var customer = new UserCommand { UserName = "customerName", Email = "test@test.com", Password = "password", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 10 };

            //Act
            var repo = new AuthRepository();
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
            var repo = new AuthRepository();
            var result = repo.Authenticate(customer.Email, customer.Password);

            //Assert
            //Assert.Fail(result);
        }
    }
}
