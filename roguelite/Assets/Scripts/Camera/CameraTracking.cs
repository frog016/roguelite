using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform _trackingObject;
    [SerializeField] private float _sensitivity;

    private void Start()
    {
        transform.position = new Vector3(_trackingObject.position.x, _trackingObject.position.y, transform.position.z);
        _trackingObject.GetComponent<MoveController>().OnPlayerMove.AddListener(FollowAtObject);
    }

    private void FollowAtObject()
    {
        var newPosition = new Vector3(_trackingObject.position.x, _trackingObject.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, _sensitivity * Time.fixedDeltaTime);
    }
}
