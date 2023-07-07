using System.ComponentModel.DataAnnotations;

namespace GEMSUI.Models
{
    public class Login
    {
        [Display(Name = "User Name")]
        [Required]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }

        public string Customer { get; set; } = null!;
        [Display(Name ="User Name")]
        [Required]
        public string Username { get; set; } = null!;
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string? Email { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string? LastName { get; set; }

        public string? Roles { get; set; }
        [Display(Name = "Is Trail User")]
        public bool TrialUser { get; set; }
    }
}
