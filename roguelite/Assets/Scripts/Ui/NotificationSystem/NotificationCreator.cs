using UnityEngine;

[RequireComponent(typeof(NotificationHandler))]
public class NotificationCreator : SingletonObject<NotificationCreator>
{
    private NotificationHandler _notificationHandler;

    protected override void Awake()
    {
        base.Awake();
        _notificationHandler = GetComponent<NotificationHandler>();
    }

    public void CreateNotification(Notification notification)
    {
        _notificationHandler.AddNotification(notification);
    }
}
