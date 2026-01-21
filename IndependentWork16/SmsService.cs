public class SmsService : ISmsService
{
    public void SendSms(string phoneNumber, string message)
    {
        Console.WriteLine($"SMS відправлено на номер {phoneNumber}: '{message}'");
    }
}
