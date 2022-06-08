using TMPro;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    protected TextMeshProUGUI _interactionText;

    protected virtual void Start()
    {
        _interactionText = FindObjectOfType<InteractionText>().Text;
    }

    protected void ShowText(string text)
    {
        if (_interactionText == null)
            return;

        _interactionText.text = text;
    }

    protected void HideText()
    {
        if (_interactionText == null)
            return;

        _interactionText.text = "";
    }

    public virtual void StartInteraction()
    {
        Debug.Log("Start Interact");
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
