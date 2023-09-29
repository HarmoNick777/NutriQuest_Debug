using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private float _deathYThreshold = -8f;
    [SerializeField] private Score _score;
    
    void Update()
    {
        if(transform.position.y < _deathYThreshold)
        {
            _score.Reset();
            Debug.Log("Player died, try again!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
