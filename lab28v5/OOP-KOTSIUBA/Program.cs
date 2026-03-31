using System;

namespace lab23
{
    // --- Інтерфейси (ISP) ---
    interface IUserRepository
    {
        void SaveUser(string username, string email, string phone);
        void Authenticate(string username);
    }

    interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }

    interface ISmsService
    {
        void SendSms(string phone, string message);
    }

    // --- Реалізації ---
    class DatabaseConnection : IUserRepository
    {
        public void SaveUser(string username, string email, string phone)
        {
            Console.WriteLine($"Saving {username} to database...");
        }

        public void Authenticate(string username)
        {
            Console.WriteLine($"{username} logged in.");
        }
    }

    class SmtpClient : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to}: {subject}");
        }
    }

    class SmsGateway : ISmsService
    {
        public void SendSms(string phone, string message)
        {
            Console.WriteLine($"Sending SMS to {phone}: {message}");
        }
    }

    // --- Головний клас з DI ---
    class UserAccountManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        // Dependency Injection через конструктор
        public UserAccountManager(IUserRepository userRepository, IEmailService emailService, ISmsService smsService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _smsService = smsService;
        }

        public void RegisterUser(string username, string email, string phone)
        {
            _userRepository.SaveUser(username, email, phone);
            _emailService.SendEmail(email, "Welcome!", "Your account is created.");
            _smsService.SendSms(phone, "Welcome to our service!");
        }

        public void LoginUser(string username)
        {
            _userRepository.Authenticate(username);
        }
    }

    // --- Main ---
    class Program
    {
        static void Main()
        {
            // Створюємо сервіси
            IUserRepository userRepository = new DatabaseConnection();
            IEmailService emailService = new SmtpClient();
            ISmsService smsService = new SmsGateway();

            // Впроваджуємо залежності через конструктор
            var manager = new UserAccountManager(userRepository, emailService, smsService);

            // Демонстрація роботи
            manager.RegisterUser("Artem", "artem@example.com", "+380123456789");
            manager.LoginUser("Artem");
        }
    }
}
