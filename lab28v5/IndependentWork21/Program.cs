using IndependentWork21.Core;
using IndependentWork21.Strategies;
using IndependentWork21.Observers;

var context = new OrderContext(new ProcessOnlineOrderStrategy());

var publisher = new OrderPublisher();

var email = new OrderConfirmationEmailObserver();
var storage = new InventoryUpdateObserver();

publisher.OrderProcessed += email.OnOrderProcessed;
publisher.OrderProcessed += storage.OnOrderProcessed;

context.Execute("Order #1");
publisher.Publish("Order #1");

Console.WriteLine();

context.SetStrategy(new ProcessCashOrderStrategy());

context.Execute("Order #2");
publisher.Publish("Order #2");

Console.WriteLine();

context.SetStrategy(new ProcessCreditCardOrderStrategy());

context.Execute("Order #3");
publisher.Publish("Order #3");