
using System.ComponentModel.DataAnnotations;

public class TokenRequest
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
