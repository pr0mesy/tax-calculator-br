using TaxCalculatorBR.Domain.Entities;
using TaxCalculatorBR.Domain.Interfaces;

namespace TaxCalculatorBR.Application.Services;

public class TaxCalculatorService : ITaxCalculatorService
{
    private readonly ITaxCalculator _icmsCalculator;
    private readonly ITaxCalculator _issCalculator;
    private readonly ITaxCalculator _ipiCalculator;

    public TaxCalculatorService(
        ITaxCalculator icmsCalculator, 
        ITaxCalculator issCalculator,
        ITaxCalculator ipiCalculator)
    {
        this._icmsCalculator = icmsCalculator;
        this._issCalculator = issCalculator;
        this._ipiCalculator = ipiCalculator;
    }


    public TaxResult Calculate(Product product, string originState, string destinationState)
    {
        decimal icmsValue = _icmsCalculator.Calculate(product, originState, destinationState);
        decimal issValue = _issCalculator.Calculate(product, originState, destinationState);
        decimal ipiValue = _ipiCalculator.Calculate(product, originState, destinationState);
        
        decimal totalTax = icmsValue + issValue + ipiValue;
        decimal finalPrice = product.Price + totalTax;

        return new(
            originState, 
            destinationState, 
            product.Type, 
            icmsValue, 
            issValue, 
            ipiValue, 
            totalTax, 
            finalPrice);
    }
}