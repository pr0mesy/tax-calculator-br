using TaxCalculatorBR.Domain.Enums;

namespace TaxCalculatorBR.Domain.Entities;

public record TaxResult(
    string OriginState,       // ex: "SP"
    string DestinationState,  // ex: "BA"
    ProductType ProductType,  // PRODUCT, SERVICE ou INDUSTRIALIZED

    decimal IcmsValue,        // valor calculado do ICMS
    decimal IssValue,         // valor calculado do ISS (0 se não for SERVICE)
    decimal IpiValue,         // valor calculado do IPI (0 se não for INDUSTRIALIZED)

    decimal TotalTax,         // IcmsValue + IssValue + IpiValue
    decimal FinalPrice        // preço original + TotalTax
);