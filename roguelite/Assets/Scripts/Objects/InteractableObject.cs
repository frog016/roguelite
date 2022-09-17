using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    private bool _isNear;

    protected void ShowText(string text)
    {
        NotificationCreator.Instance.CreateNotification(new Notification(NotificationMode.Tooltip, text));
    }

    protected void HideText()
    {
        NotificationCreator.Instance.CreateNotification(new Notification(NotificationMode.Tooltip, ""));
    }

    public virtual void StartInteraction()
    {
        _isNear = true;
        ShowText("Нажмите E для взаимодействия");
    }

    public virtual void Interaction()
    {
    }

    public virtual void EndInteraction()
    {
        HideText();
        _isNear = false;
    }

    protected virtual void Update()
    {
        if (_isNear)
            Interaction();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        StartInteraction();
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        EndInteraction();
    }
}
