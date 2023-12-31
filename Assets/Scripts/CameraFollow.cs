using UnityEngine;

/// <summary>
/// Makes the camera follow a specific GameObject target, most often the player.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] public Transform target;

    [Header("Parameters")]
    [SerializeField] private float _smoothTime = 0.3f;

    private Vector3 _offset;
    private Vector3 _velocity = Vector3.zero;

    private void Start()
    {
        _offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, _smoothTime);
    }
}
