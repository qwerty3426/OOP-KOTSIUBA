public interface IPaymentGateway
{
    void Charge(decimal amount, string cardNumber);
}
