namespace backend_api.Models;

public class Post
{
    public int PostId { get; set; }

    public string? Chirp { get; set; }

    public string ChirpDate = DateTime.Now.ToString("g");

    public int UserId { get; set; }
    public User? User { get; set; }

}