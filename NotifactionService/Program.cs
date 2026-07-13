
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace Notify
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            NotificationService emailService = new NotificationService(new EmailSender());
            emailService.NotifyUser("Alice", "Deine Registrieung war erfolgreich!");


            NotificationService smsService = new NotificationService(new SmSSender());
            smsService.NotifyUser("+435676998533", "Deine Verfizierungscode lautet: 123456");

            Console.ReadKey();


        }
    }

    // 2. Definition des Interfaces IMessageService 
    public interface IMessageService
    {
        void SendMessage(string recipient, string message);
    }

    // Konkrete Implementations of IMessageService
    public class EmailSender : IMessageService
    {
        public void SendMessage(string recipient, string message)
        {
            Console.WriteLine($"Sending Email to {recipient} with message: {message}");
        }
    }

    public class SmSSender : IMessageService
    {
        public void SendMessage(string recipient, string message)
        {
            Console.WriteLine($"Sending SMS to {recipient} with message: {message}");
        }
    }

    // 3. Implementierung der Factory-Klasse , Der Service nutzt nun das Interface (Dependency Injection) und ist somit flexibel und erweiterbar.

    public class NotificationService
    {
        private IMessageService _sender;

        // Konstruktor, der eine IMessageService-Implementierung entgegennimmt
        public NotificationService(IMessageService sender)
        {
            _sender = sender;
        }

        public void NotifyUser(string user, string msg)
        {
            string formattedMessage = $"Hallo {user}, {msg}";
            _sender.SendMessage(user, formattedMessage);
        }


    }

}