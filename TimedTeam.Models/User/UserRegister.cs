
using System.ComponentModel.DataAnnotations;

public class UserRegister
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(4)]
    public string UserName { get; set; }

    [Required]
    [MinLength(4)]
    public string Password { get; set; }

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
