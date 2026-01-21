public class PaymentGateway : IPaymentGateway
{
    public void Charge(decimal amount, string cardNumber)
    {
        Console.WriteLine($"Списано {amount} грн з картки {cardNumber}.");
    }
}
