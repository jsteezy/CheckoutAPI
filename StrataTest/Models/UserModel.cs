namespace StrataTest.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public CustomerLoyalty LoyaltyLevel { get; set; }
        public decimal YearlySpend { get; set; }
        public int BasketId { get; set; }
        public BasketModel Basket { get; set; }
    }

    public enum CustomerLoyalty
    {
        Gold,
        Silver,
        Standard
    }
}