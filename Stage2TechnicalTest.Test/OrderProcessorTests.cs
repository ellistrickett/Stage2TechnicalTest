using System;
using System.Collections.Generic;
using Stage2TechincalTest;
using Xunit;

namespace Stage2TechincalTest.Test;
public class OrderProcessorTests
{
    private readonly OrderProcessor orderProcessor;

    public OrderProcessorTests()
    {
        orderProcessor = new OrderProcessor();
    }

    [Fact]
    public void ProcessOrder_ShouldReturnConfirmed_ForRepairOrder_NotRush_NewCustomer_NotLarge()
    {
        Order order = new Order
        {
            IsRushOrder = false,
            OrderType = OrderType.Repair,
            IsNewCustomer = true,
            IsLargeOrder = false
        };

        OrderStatus status = orderProcessor.ProcessOrder(order);

        Assert.Equal(OrderStatus.Confirmed, status);
    }

    [Fact]
    public void ProcessOrder_ShouldReturnAuthorisationRequired_ForRepairOrder_Rush_NotNewCustomer_NotLarge()
    {
        Order order = new Order
        {
            IsRushOrder = true,
            OrderType = OrderType.Repair,
            IsNewCustomer = false,
            IsLargeOrder = false
        };

        OrderStatus status = orderProcessor.ProcessOrder(order);

        Assert.Equal(OrderStatus.AuthorisationRequired, status);
    }

    [Fact]
    public void ProcessOrder_ShouldReturnClosed_ForHireOrder_Rush_NotNewCustomer_Large()
    {
        Order order = new Order
        {
            IsRushOrder = true,
            OrderType = OrderType.Hire,
            IsNewCustomer = false,
            IsLargeOrder = true
        };

        OrderStatus status = orderProcessor.ProcessOrder(order);

        Assert.Equal(OrderStatus.Closed, status);
    }

}
