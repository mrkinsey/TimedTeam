
using System.ComponentModel.DataAnnotations;

public class PostCreate
{
    [Required]
    [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
    [MaxLength(24, ErrorMessage = "{0} must contain no more than {1} characters.")]
    public string Title { get; set; }

    [Required]
    [MaxLength(400, ErrorMessage = "{0} must contain no more than {1} characters.")]
    public string Text { get; set; }

    public int AuthorId { get; set; }
}