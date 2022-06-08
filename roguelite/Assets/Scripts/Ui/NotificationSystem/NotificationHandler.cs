using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _announcement;
    [SerializeField] private TextMeshProUGUI _tooltip;
    [SerializeField] private float _delayBetweenAnnouncements;

    private bool _isLaunched;
    private Queue<string> _announcementQueue;

    private void Awake()
    {
        _announcementQueue = new Queue<string>();
    }

    public void AddNotification(Notification notification)
    {
        switch (notification.Mode)
        {
            case NotificationMode.Announcement:
                PublishAnnouncement(notification.Message);
                break;

            case NotificationMode.Tooltip:
                _tooltip.text = notification.Message;
                break;
        }
    }

    private void PublishAnnouncement(string message)
    {
        _announcementQueue.Enqueue(message);

        if (!_isLaunched)
            StartCoroutine(LaunchAnnouncementOutput());
    }

    private IEnumerator LaunchAnnouncementOutput()
    {
        _isLaunched = true;

        while (_announcementQueue.Count > 0)
        {
            var announcement = _announcementQueue.Dequeue();
            _announcement.text = announcement;
            yield return new WaitForSeconds(_delayBetweenAnnouncements);
            _announcement.text = "";
        }

        _isLaunched = false;
    }
}
