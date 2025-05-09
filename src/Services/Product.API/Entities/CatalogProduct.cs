using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API.Entities;

using Contracts.Domains;

public class CatalogProduct : EntityAuditBase<long>
{
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string? No { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(250)")]
    public string? Name { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(250)")]
    public string? Summary { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(250)")]
    public string? Description { get; set; }

    public decimal Price { get; set; }
}
