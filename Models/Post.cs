using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_api.Models;

public class Post
{
    [JsonIgnore]
    public int PostId { get; set; }

    [Required]
    public string? Chirp { get; set; }

    public string ChirpDate => DateTime.Now.ToString("dd MMMM yyyy");

    public int UserId {get; set;}
    

    [ForeignKey("UserId")]

    public User user { get; set;}

    // public virtual ICollection<User> Users { get; set; }

}