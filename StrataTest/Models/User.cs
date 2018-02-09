namespace StrataTest.Models
{
    public class User
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public CustomerLoyalty LoyaltyLevel { get; set; }
        public decimal YearlySpend { get; set; }
    }

    public enum CustomerLoyalty
    {
        Gold,
        Silver,
        Standard
    }
}