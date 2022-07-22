namespace MoviesWatchlist.ScheduledService;

public interface INotificationSender
{
    Task SendNotifications();
}