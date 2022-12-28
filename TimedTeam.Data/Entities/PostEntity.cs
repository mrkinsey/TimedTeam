
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PostEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Text { get; set; }

    [Required]
    public DateTimeOffset PostDate { get; set; }

    [Required]
    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }
    public virtual UserEntity Author { get; set; }
}
