using UnityEngine;
using NaughtyAttributes;
using TNRD;

/// <summary>
/// Handles the player's animations.
/// </summary>
public class PlayerAnimations : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator _animator;

    [Header("Parameters")]
    [SerializeField, AnimatorParam(nameof(_animator))] private string _speedParam = "Speed";
    [SerializeField, AnimatorParam(nameof(_animator))] private string _groundedParam = "Grounded";

    /// <summary>
    /// Handles the player's movement animation based on the given speed.
    /// </summary>
    /// <param name="speed">the speed at which the player is moving</param>
    public void Move(float speed)
    {
        _animator.SetFloat(_speedParam, speed);
    }

    /// <summary>
    /// Handles the player's jump animation based on its grounded status.
    /// </summary>
    /// <param name="grounded">the player’s current grounded status</param>
    public void SetGrounded(bool grounded)
    {
        _animator.SetBool(_groundedParam, grounded);
    }
}
