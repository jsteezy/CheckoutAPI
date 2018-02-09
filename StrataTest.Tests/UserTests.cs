using NUnit.Framework;
using StrataTest.Models;
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
            var customer = new User { Name = "customerName", EmailAddress = "test@test.com", Password = "password", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 10};

           //Act
           var repo = new UserRepository(DataLocation);
            var customerFromJson = repo.GetUserByName(customer.Name);

            //Assert
            Assert.AreEqual(customer.Name, customerFromJson.Name);
            Assert.AreEqual(customer.EmailAddress, customerFromJson.EmailAddress);
            Assert.AreEqual(customer.Password, customerFromJson.Password);
            Assert.AreEqual(customer.LoyaltyLevel, customerFromJson.LoyaltyLevel);
            Assert.AreEqual(customer.YearlySpend, customerFromJson.YearlySpend);
        }

        [Test]
        public void AddUserToStorage()
        {
            //Arrange
            var newCustomer = new User { Name = "customerName1", EmailAddress = "test1@test.com", Password = "password1", LoyaltyLevel = CustomerLoyalty.Standard, YearlySpend = 0 };

            //Act
            var repo = new UserRepository(DataLocation);
            repo.AddUser(newCustomer);

            //Assert
            var customerFromJson = repo.GetUserByName(newCustomer.Name);
            Assert.AreEqual(newCustomer.Name, customerFromJson.Name);
            Assert.AreEqual(newCustomer.EmailAddress, customerFromJson.EmailAddress);
            Assert.AreEqual(newCustomer.Password, customerFromJson.Password);
            Assert.AreEqual(newCustomer.LoyaltyLevel, customerFromJson.LoyaltyLevel);
            Assert.AreEqual(newCustomer.YearlySpend, customerFromJson.YearlySpend);

        }
    }
}
