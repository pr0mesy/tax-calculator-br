using TaxCalculatorBR.Domain.Enums;

namespace TaxCalculatorBR.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    
    public ProductType Type { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public decimal Price { get; set; }
}