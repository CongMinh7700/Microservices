using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.Products;

public class CreateOrUpdateDto
{
    [Required]
    [MaxLength(250, ErrorMessage = "Maximum length for ProductName is 250 characters")]
    public string? Name { get; set; }

    [Required]
    [MaxLength(255, ErrorMessage = "Maximum length for Summary is 255 characters")]
    public string? Summary { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }
}
