using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IInteractable
{
    public GameObject ParticleEffect;

    private GameManager _gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        if (_gameManager == null)
            Debug.LogError("GameManager not found in the scene. Make sure it exists.");
    }
  

    public void StartInteraction()
    {
        //spawn particle effect
        Debug.Log("Player hit enemy");
        gameObject.SetActive(false);
        if(_gameManager != null)
        {
            _gameManager.gameLosePanel.SetActive(true);
            //Time.timeScale = 0;
        }
        
    }
    public void StopInteraction()
    {
        //destroy enemy + its particle effect
    }

}
