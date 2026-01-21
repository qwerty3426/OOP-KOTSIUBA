public class PaymentValidator : IPaymentValidator
{
    public bool Validate(decimal amount, string cardNumber)
    {
        return amount > 0 && !string.IsNullOrEmpty(cardNumber);
    }
}
