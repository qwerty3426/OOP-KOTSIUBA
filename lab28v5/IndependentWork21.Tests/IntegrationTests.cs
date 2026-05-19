using Xunit;
using IndependentWork21.Core;
using IndependentWork21.Strategies;

namespace IndependentWork21.Tests;

public class IntegrationTests
{
    [Fact]
    public void Online_Order_Test()
    {
        var context = new OrderContext(new ProcessOnlineOrderStrategy());

        context.Execute("Order");

        Assert.True(true);
    }

    [Fact]
    public void Cash_Order_Test()
    {
        var context = new OrderContext(new ProcessCashOrderStrategy());

        context.Execute("Order");

        Assert.True(true);
    }

    [Fact]
    public void Card_Order_Test()
    {
        var context = new OrderContext(new ProcessCreditCardOrderStrategy());

        context.Execute("Order");

        Assert.True(true);
    }

    [Fact]
    public void Empty_Order_Test()
    {
        var context = new OrderContext(new ProcessOnlineOrderStrategy());

        context.Execute("");

        Assert.True(true);
    }

    [Fact]
    public void Null_Strategy_Test()
    {
        Assert.Throws<NullReferenceException>(() =>
        {
            var context = new OrderContext(null!);

            context.Execute("Test");
        });
    }
}