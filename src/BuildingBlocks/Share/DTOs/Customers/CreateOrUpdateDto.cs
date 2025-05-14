using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.Customers;

public class CreateOrUpdateDto
{
    [Required]
    public string? Username { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "Maximum length for FirstName is 255 characters")]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(150, ErrorMessage = "Maximum length for LastName is 255 characters")]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string? EmailAddress { get; set; }
}
