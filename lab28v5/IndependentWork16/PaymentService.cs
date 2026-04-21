public class PaymentService
{
    private readonly IPaymentValidator _validator;
    private readonly IPaymentGateway _gateway;
    private readonly ITransactionLogger _logger;
    private readonly ISmsService _smsService;

    public PaymentService(IPaymentValidator validator,
                          IPaymentGateway gateway,
                          ITransactionLogger logger,
                          ISmsService smsService)
    {
        _validator = validator;
        _gateway = gateway;
        _logger = logger;
        _smsService = smsService;
    }

    public void ProcessPayment(decimal amount, string cardNumber, string phoneNumber)
    {
        if (!_validator.Validate(amount, cardNumber))
        {
            Console.WriteLine("Помилка валідації платежу.");
            return;
        }

        _gateway.Charge(amount, cardNumber);
        _logger.Log(amount);
        _smsService.SendSms(phoneNumber, $"Платіж {amount} грн успішний.");
    }
}
