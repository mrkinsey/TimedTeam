using System.ComponentModel.DataAnnotations;

public class Reply
{
    [Key]
    public int ReplyId {get; set;}

    [Required]
    public int CustomerId {get; set;}

    [Required]
    public string Text {get; set;}
    
    [Required]
    public Guid AuthorId {get; set;}
}