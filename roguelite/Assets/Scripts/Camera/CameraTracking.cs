using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraTracking : MonoBehaviour
{
    [SerializeField] private float _sensitivity;

    private Transform _trackingObject;

    public void SetObject(Transform trackingTransform)
    {
        _trackingObject = trackingTransform;
        transform.position = new Vector3(_trackingObject.position.x, _trackingObject.position.y, transform.position.z);
        _trackingObject.GetComponent<MoveController>().OnObjectMovedEvent.AddListener(FollowAtObject);
    }

    private void FollowAtObject()
    {
        var newPosition = new Vector3(_trackingObject.position.x, _trackingObject.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, _sensitivity * Time.fixedDeltaTime);
    }
}
