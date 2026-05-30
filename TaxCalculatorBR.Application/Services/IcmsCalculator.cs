using TaxCalculatorBR.Domain.Entities;
using TaxCalculatorBR.Domain.Enums;
using TaxCalculatorBR.Domain.Interfaces;

namespace TaxCalculatorBR.Application.Services;

public class IcmsCalculator : ITaxCalculator
{
    
    private readonly IAliquotaRepository _repository;

    public decimal Calculate(Product product, string originState, string destinationState)
    {
        if (product.Type == ProductType.SERVICE)
            return 0;

        decimal aliquota;

        // alíquota interna
        if (originState == destinationState)
        {
            aliquota = _repository.GetIcmsAliquota(originState);
        }

        // alíquota estadual
        else
        {
            aliquota = _repository.GetIcmsInterestaduais(originState, destinationState);
        }

        return product.Price * (aliquota / 100);
    }
}