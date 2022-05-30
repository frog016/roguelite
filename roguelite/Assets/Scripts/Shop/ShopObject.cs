using UnityEngine;

public class ShopObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        Shop.Instance.OpenPanel();
    }
}
