using Core.Builder;
using Core.Enums;
using FluentAssertions;
using FluentAssertions.Execution;

namespace RdiTest.Core.Tests;

public sealed class OrderBuilderTests
{
    private OrderBuilder _sut;
    public OrderBuilderTests()
    {
        // System under testing
        _sut = new OrderBuilder();
    }
    
    [InlineData(DessertType.Sunday, 1)]
    [InlineData(DessertType.Cone, 3)]
    [InlineData(DessertType.Pie, 4)]
    [InlineData(DessertType.Shake, 100)]
    [Theory]
    public void AddDessertOrder_WhenAddingDessertType_ShouldIncreaseDesertCountByQuantity(DessertType dessertType, int portionQuantity)
    {
        // Arrange

        // Act
        _sut.AddDessertOrder(dessertType, portionQuantity);
        var responseObj = _sut.Build();

        // Assert
        using var _ = new AssertionScope();
        
        responseObj.IsSuccess.Should()
            .BeTrue(because: "Theres no reason to fail in this case");

        responseObj.Value.DessertOrders.Should()
            .ContainSingle(desertOrder => desertOrder.DessertType == dessertType 
                                          && desertOrder.PortionQuantity == portionQuantity);
    }
}