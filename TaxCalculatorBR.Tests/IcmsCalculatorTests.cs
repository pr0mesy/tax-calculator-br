using Moq;
using TaxCalculatorBR.Application.Services;
using TaxCalculatorBR.Domain.Entities;
using TaxCalculatorBR.Domain.Enums;
using TaxCalculatorBR.Domain.Interfaces;

namespace TaxCalculatorBR.Tests;

public class IcmsCalculatorTests
{
    private readonly Mock<IAliquotaRepository> _mockRepository;
    private readonly IcmsCalculator _calculator;

    public IcmsCalculatorTests()
    {
        _mockRepository = new Mock<IAliquotaRepository>();
        _calculator = new IcmsCalculator(_mockRepository.Object);
    }

    [Fact]
    public void Calculate_SameState_ShouldApplyInternalAliquota()
    {
        // arrange
        _mockRepository
            .Setup(r => r.GetIcmsAliquota("SP"))
            .Returns(18m);

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Notebook",
            Price = 5000m,
            Type = ProductType.PRODUCT
        };

        // act
        var result = _calculator.Calculate(product, "SP", "SP");

        // assert
        Assert.Equal(900m, result);
    }
    
    [Fact]
    public void Calculate_SpToBa_ShouldApply7Percent()
    {
        // arrange
        _mockRepository
            .Setup(r => r.GetIcmsInterestaduais("SP", "BA"))
            .Returns(7m);

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Notebook",
            Price = 5000m,
            Type = ProductType.PRODUCT
        };
        
        // act
        var result = _calculator.Calculate(product, "SP", "BA");
        
        // assert
        Assert.Equal(350m, result);
    }

    [Fact]
    public void Calculate_BaToSp_ShouldApply12Percent()
    {
        _mockRepository
            .Setup(t => t.GetIcmsInterestaduais("BA", "SP"))
            .Returns(12m);

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Notebook",
            Price = 5000m,
            Type = ProductType.PRODUCT
        };
        
        var result = _calculator.Calculate(product, "BA", "SP");
        
        Assert.Equal(600m, result);
    }
    
    [Fact]
    public void Calculate_ServiceProduct_ShouldReturn0()
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Fazer um site",
            Price = 2599m,
            Type = ProductType.SERVICE
        };

        var result = _calculator.Calculate(product, "BA", "BA");

        Assert.Equal(0m, result);
        _mockRepository.Verify(r => r.GetIcmsAliquota(It.IsAny<string>()), Times.Never);
    }


}