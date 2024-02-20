using System.Net;
using System.Net.Http.Json;
using Application.Command;
using Core.Enums;
using Core.OrderRequest;
using FluentAssertions;

namespace RdiTest.Api.Tests;

public class OrdersFunctionalTests(OrdersWebApiFactory factory) 
    : IClassFixture<OrdersWebApiFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task PostOrder_WhenOrderIsValid_ShouldReturnOkResponse()
    {
        // Arrange
        List<DessertOrder> dessertOrders = [new DessertOrder(DessertType.Cone, 1)];
        List<GrillOrder> grillOrders = [];
        List<SaladOrder> saladOrders = [];
        List<FriesOrder> friesOrders = [];

        OrderCommand createOrderCommand = new OrderCommand(dessertOrders, friesOrders, grillOrders, saladOrders);

        // Act
        var response = await _client.PostAsJsonAsync("Order", createOrderCommand);
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
}