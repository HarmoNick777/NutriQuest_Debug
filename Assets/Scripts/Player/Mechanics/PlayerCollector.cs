using UnityEngine;

/// <summary>
/// Collects the different collectibles the player encounters.
/// </summary>
public class PlayerCollector : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _detectorLength;

    private RaycastHit _hit;

    private void FixedUpdate()
    {
        // Check if the player is colliding with a collectible
        if (Physics.Raycast(transform.position, transform.forward, out _hit, _detectorLength))
        {
            // Check if the collectible implements the ICollect interface
            if (_hit.collider.TryGetComponent(out ICollect collectible))
            {
                // Collect the collectible
                collectible.Collect();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * _detectorLength);
    }
}
