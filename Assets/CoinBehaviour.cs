using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour, IInteractable
{
    ScoreManager _scoreManager;
    public int value;

    void Awake()
    {
        //todo "use event instead of this"
        _scoreManager = FindObjectOfType<ScoreManager>();
        if (_scoreManager == null) 
            Debug.LogError("ScoreManager not found in the scene. Make sure it exists.");
    }

    public void StartInteraction()
    {
        if (_scoreManager != null)
        {
            _scoreManager.UpdateScore(value);
        }
        else 
            Debug.LogError("ScoreManager is null.");
        
        gameObject.SetActive(false);
    }

    public void StopInteraction()
    {
    }
}