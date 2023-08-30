using System.ComponentModel.DataAnnotations;

namespace backend_api.Models;

public class User {
    // public int CoffeeId { get; set; }

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

} 



