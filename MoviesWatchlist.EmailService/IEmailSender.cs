namespace MoviesWatchlist.EmailService;

public interface IEmailSender
{
    Task SendEmail(string body, string receiver);
}