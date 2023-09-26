using TNRD;
using UnityEngine;

/// <summary>
/// Adds a score value to the player score when executed.
/// </summary>
public class FoodScoreEffect : MonoBehaviour, IExecute
{
    [Header("Data")]
    [SerializeField] private SerializableInterface<IAdd<int>> _scoreAddSerialized;

    [Header("Parameters")]
    [SerializeField] private int _scoreValue;

    // Properties for the interfaces
    private IAdd<int> _scoreAdd => _scoreAddSerialized.Value;

    /// <summary>
    /// Executes the score effect, adding the corresponding value to the player score.
    /// </summary>
    public void Execute()
    {
        // Add score
        _scoreAdd.Add(_scoreValue);
    }
}
