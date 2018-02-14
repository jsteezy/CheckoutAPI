using System.ComponentModel.DataAnnotations;
using StrataTest.Enums;
using StrataTest.Models;

namespace StrataTest.Commands
{
    public class UserCommand
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public CustomerLoyalty LoyaltyLevel { get; set; }
        public decimal YearlySpend { get; set; }
        public int BasketId { get; set; }
        public BasketModel Basket { get; set; }
    }
}