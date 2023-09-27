using System;
using UnityEngine;

/// <summary>
/// Detects whether the player is grounded or not.
/// </summary>
public class PlayerGroundDetector : MonoBehaviour, IGrounded
{
    [Header("Components")]
    [SerializeField] private Transform _groundCheck;

    [Header("Parameters")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckRadius = 0.1f;

    [Header("Animations")]
    [SerializeField] private PlayerAnimations _animations;

    // Properties for the interfaces
    public bool isGrounded { get; private set; }

    public event Action OnGrounded;

    private bool _lastGroundedStatus;

    private void FixedUpdate()
    {
        _lastGroundedStatus = isGrounded;

        // Check if the player is grounded and updates the grounded status accordingly
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundLayer);
        Debug.Log(isGrounded);

        // Update the animations if the grounded status changed
        if (_lastGroundedStatus != isGrounded)
        {
            _animations.SetGrounded(isGrounded);
        }

        // Invoke the event if the grounded status changed from false to true
        if (isGrounded && !_lastGroundedStatus)
        {
            OnGrounded?.Invoke();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
    }
}
