using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCoinforScroll : MonoBehaviour, IInteractable
{
    ScoreManager _scoreManager;

    void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        if (_scoreManager == null) 
            Debug.LogError("ScoreManager not found in the scene. Make sure it exists.");
    }

    public void StartInteraction()
    {
        if (_scoreManager != null)
        {
            _scoreManager.UpdateScore(2);
        }
        else 
            Debug.LogError("ScoreManager is null.");
        
        gameObject.SetActive(false);
        //EnemyBehaviour.setActive(false);
    }

    public void StopInteraction()
    {
    }
}