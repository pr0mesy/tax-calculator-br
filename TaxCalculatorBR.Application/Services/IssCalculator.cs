using TaxCalculatorBR.Domain.Entities;
using TaxCalculatorBR.Domain.Enums;
using TaxCalculatorBR.Domain.Interfaces;

namespace TaxCalculatorBR.Application.Services;

public class IssCalculator : ITaxCalculator
{
    public Decimal Calculate(Product product, string _, string __)
    {
        if (product.Type != ProductType.SERVICE)
        {
            return 0;
        }
        
        return product.Price * (5 / 100m);
    }

}