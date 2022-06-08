public class Notification
{
    public readonly NotificationMode Mode;
    public readonly string Message;

    public Notification(NotificationMode mode, string message)
    {
        Mode = mode;
        Message = message;
    }
}
