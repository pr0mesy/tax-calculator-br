using TaxCalculatorBR.Domain.Entities;
using TaxCalculatorBR.Domain.Enums;
using TaxCalculatorBR.Domain.Interfaces;

namespace TaxCalculatorBR.Application.Services;

public class IpiCalculator : ITaxCalculator
{
    public Decimal Calculate(Product product, string _, string __)
    {
        if (product.Type != ProductType.INDUSTRIALIZED)
        {
            return 0;
        }
        
        return product.Price * (10 / 100m);
    }
}