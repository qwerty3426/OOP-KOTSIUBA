using IndependentWork20.Core;
using IndependentWork20.Strategies;
using IndependentWork20.Observers;

var context = new OrderContext(new ProcessOnlineOrderStrategy());

var publisher = new OrderPublisher();

var emailObserver = new OrderConfirmationEmailObserver();
var inventoryObserver = new InventoryUpdateObserver();

publisher.OrderProcessed += emailObserver.OnOrderProcessed;
publisher.OrderProcessed += inventoryObserver.OnOrderProcessed;

context.Execute("Замовлення #1");
publisher.Publish("Замовлення #1");

Console.WriteLine();

context.SetStrategy(new ProcessCashOrderStrategy());

context.Execute("Замовлення #2");
publisher.Publish("Замовлення #2");

Console.WriteLine();

context.SetStrategy(new ProcessCreditCardOrderStrategy());

context.Execute("Замовлення #3");
publisher.Publish("Замовлення #3");