public interface IPaymentValidator
{
    bool Validate(decimal amount, string cardNumber);
}
