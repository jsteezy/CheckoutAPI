namespace StrataTest.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public CustomerLoyalty LoyaltyLevel { get; set; }
        public decimal YearlySpend { get; set; }
        public int BasketId { get; set; }
        //TODO orders should be IEnumerable object contained by user
    }

    public enum CustomerLoyalty
    {
        Gold,
        Silver,
        Standard
    }
}