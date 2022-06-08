using TMPro;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class InteractableObject : MonoBehaviour, IInteractable
{
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
        ShowText("Press E to interact");
    }

    public virtual void Interaction()
    {
    }

    public virtual void EndInteraction()
    {
        HideText();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        StartInteraction();
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        Interaction();
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        EndInteraction();
    }
}
