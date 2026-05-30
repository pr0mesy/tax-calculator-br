using TaxCalculatorBR.Domain.Entities;

namespace TaxCalculatorBR.Domain.Interfaces;

public interface ITaxCalculatorService
{
    TaxResult Calculate(Product product, string originState, string destinationState);
}