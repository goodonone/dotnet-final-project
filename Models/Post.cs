using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend_api.Models;

public class Post
{
    [JsonIgnore]
    public int PostId { get; set; }

    [Required]
    public string? Chirp { get; set; }

    public string ChirpDate => DateTime.Now.ToString("dd MMMM yyyy");

}