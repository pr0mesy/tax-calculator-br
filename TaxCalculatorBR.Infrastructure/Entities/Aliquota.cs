using System.ComponentModel.DataAnnotations;

namespace TaxCalculatorBR.Infrastructure.Entities;

public class Aliquota
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string OriginState { get; set; } = string.Empty;
    
    [Required]
    public string DestinationState { get; set; } = string.Empty;
    
    [Required]
    public decimal AliquotaValue { get; set; }
    
    [Required]
    public string TaxType { get; set; } = string.Empty;
}