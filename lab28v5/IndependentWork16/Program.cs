using System;

class Program
{
    static void Main()
    {
        // Створюємо реалізації інтерфейсів
        IPaymentValidator validator = new PaymentValidator();
        IPaymentGateway gateway = new PaymentGateway();
        ITransactionLogger logger = new TransactionLogger();
        ISmsService sms = new SmsService();

        // Створюємо сервіс
        PaymentService paymentService = new PaymentService(validator, gateway, logger, sms);

        // Виконуємо платіж
        paymentService.ProcessPayment(1500m, "1234-5678-9012-3456", "+380991112233");

        Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}
