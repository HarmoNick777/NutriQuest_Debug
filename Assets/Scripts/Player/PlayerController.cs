using UnityEngine;
using NaughtyAttributes;
using TNRD;

public class PlayerController : MonoBehaviour
{
    [Header("Mechanics")]
    [SerializeField, Label("Movement")] private SerializableInterface<IMove> _movementSerialized;
    [SerializeField, Label("Jump")] private SerializableInterface<IJump> _jumpSerialized;

    [Header("Input Parameters")]
    [SerializeField, InputAxis] private string _horizontalAxis;
    [SerializeField, InputAxis] private string _verticalAxis;
    [SerializeField, InputAxis] private string _jumpButton;

    // Properties for the interfaces
    private IMove _movement => _movementSerialized.Value;
    private IJump _jump => _jumpSerialized.Value;

    private void Update()
    {
        // Movement
        _movement.Move(new Vector2(Input.GetAxisRaw(_horizontalAxis), Input.GetAxisRaw(_verticalAxis)).normalized);

        // Jump
        if (Input.GetButtonDown(_jumpButton))
        {
            _jump.Jump();
        }
    }
}
