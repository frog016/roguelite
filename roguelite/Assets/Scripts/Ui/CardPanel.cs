using UnityEngine;

public abstract class CardPanel<T> : SingletonObject<T> where T: SingletonObject<T>
{
    [SerializeField] protected GameObject _cardPrefab;
    [SerializeField] protected GameObject _cardList;

    protected bool _isOpened;

    protected virtual void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenPanel(InteractableObject interactableObject)
    {
        PauseManager.Instance.Stop();
        gameObject.SetActive(true);
        if (!_isOpened)
            GenerateCards(interactableObject);
    }

    public void ClosePanel()
    {
        PauseManager.Instance.Continue();
        gameObject.SetActive(false);
    }

    protected abstract void GenerateCards(InteractableObject interactableObject);
}
