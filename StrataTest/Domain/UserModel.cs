using Microsoft.AspNet.Identity.EntityFramework;
using StrataTest.Enums;
using StrataTest.Models;

namespace StrataTest.Domain
{
    public class UserModel : IdentityUser
    {
        public CustomerLoyalty LoyaltyLevel { get; set; }
        public decimal YearlySpend { get; set; }
        public int BasketId { get; set; }
        public BasketModel Basket { get; set; }
    }
}
