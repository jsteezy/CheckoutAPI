using System;
using System.IO;
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
    }
}
