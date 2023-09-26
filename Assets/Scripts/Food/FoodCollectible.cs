using NaughtyAttributes;
using TNRD;
using UnityEngine;

/// <summary>
/// Handles the collectible mechanic of foods.
/// </summary>
public class FoodCollectible : MonoBehaviour
{
    [SerializeField, Label("Score Effect")] private SerializableInterface<IExecute> _scoreEffectSerialized;

    // Properties for the interfaces
    private IExecute _scoreEffect => _scoreEffectSerialized.Value;

    /// <summary>
    /// Collects the food.
    /// </summary>
    public void Collect()
    {
        _scoreEffect.Execute();
        gameObject.SetActive(false);
    }
}
