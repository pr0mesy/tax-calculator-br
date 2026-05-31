using TaxCalculatorBR.Application.Services;
using TaxCalculatorBR.Domain.Entities;
using TaxCalculatorBR.Domain.Enums;

namespace TaxCalculatorBR.Tests;

public class IpiCalculatorTests
{
    private readonly IpiCalculator _calculator;

    public IpiCalculatorTests()
    {
        _calculator = new IpiCalculator();
    }

    [Fact]
    public void Calculate_IndustrializedProduct_ShouldApply10Percent()
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "IndustrializedProduct",
            Price = 100,
            Type = ProductType.INDUSTRIALIZED
        };
        
        var result = _calculator.Calculate(product, "_", "__");
        Assert.Equal(10m, result);
    }
    
    [Fact]
    public void Calculate_Product_ShouldReturn0()
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Mouse",
            Price = 110,
            Type = ProductType.PRODUCT
        };
        
        var result = _calculator.Calculate(product, "_", "__");
        Assert.Equal(0m, result);
    }
    
    [Fact]
    public void Calculate_IndustrializedProduct_ShouldReturn0()
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Levantar um muro",
            Price = 500,
            Type = ProductType.SERVICE
        };
        
        var result = _calculator.Calculate(product, "_", "__");
        Assert.Equal(0m, result);
    }
} 