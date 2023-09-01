using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_api.Models;

public class Post
{
    [JsonIgnore]
    public int PostId { get; set; }

    [Required]
    public string Chirp { get; set; }

    public string ChirpDate = DateTime.Now.ToString("g");

    public int? UserId { get; set; }
    public User? User { get; set; }

    // public List<User> Users { get; } = new();
    
    // public int UserId { get; internal set; }

    // public int UserId { get; set; }
    // public User User { get; set; }

    // public virtual ICollection<User> Users { get; set; }

}