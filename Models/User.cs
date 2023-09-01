using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace backend_api.Models;

public class User {
    
    [JsonIgnore]
    public int UserId { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? UserName { get; set; }

    [Required]
    public string? City { get; set; }

    [Required]
    public string? State { get; set; }

    [Required, Range(1000, 99999, ErrorMessage = "Please enter a valid ZipCode")]
    public int ZipCode { get; set; }

    public string MemberSince = DateTime.Now.ToString("dd MMMM yyyy");

    public string? PhotoURL { get; set; }

    public ICollection<Post> Posts { get; } = new List<Post>();


    // [ForeignKey("PostId")]

    // public List<Post> Posts { get; } = new();

    // public List<Tag> Tags { get; } = new();
    // public Post post { get; set;}

    // public virtual ICollection<Post> Posts { get; set; }

}


