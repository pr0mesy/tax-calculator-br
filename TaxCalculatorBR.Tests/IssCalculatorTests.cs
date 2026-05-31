using Moq;
using TaxCalculatorBR.Application.Services;
using TaxCalculatorBR.Domain.Entities;
using TaxCalculatorBR.Domain.Enums;
using TaxCalculatorBR.Domain.Interfaces;

namespace TaxCalculatorBR.Tests;

public class IssCalculatorTests
{
    private readonly IssCalculator _calculator;

    public IssCalculatorTests()
    {
        _calculator = new IssCalculator();
    }

    [Fact]
    public void Calculate_Service_ShouldApply5Percent()
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Levantar um muro",
            Price = 500,
            Type = ProductType.SERVICE
        };
        
        var result = _calculator.Calculate(product, "_", "__");
        Assert.Equal(25m, result);
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
            Name = "Panela",
            Price = 69,
            Type = ProductType.INDUSTRIALIZED
        };
        
        var result = _calculator.Calculate(product, "_", "__");
        Assert.Equal(0m, result);
    }
}