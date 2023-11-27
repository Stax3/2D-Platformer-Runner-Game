using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class GameManager : MonoBehaviour
{
    public GameObject gameLosePanel;
    DistanceTracker _distanceTracker;
    public bool gameRunning;
    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;
    }

    private void Awake()
    {
       _distanceTracker = FindObjectOfType<DistanceTracker>();
    }

    // Update is called once per frame
    public void Replaybtn()
    {
        if (_distanceTracker == null)
        {
            Debug.Log("DistanceTracker reference is null!");
            return;
        }
        else
        {
            Debug.Log("Distance will reset in replay button");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            _distanceTracker.ResetDistance();
            gameLosePanel.SetActive(false);
            //Time.timeScale =1f
        }
        
    }
    
    public void Pausee()
    {
        Time.timeScale = 0;
        _distanceTracker.gameRunning = false;
        
    }
    public void Resumee()
    {
        Time.timeScale = 1;
        _distanceTracker.gameRunning = true;
    }
    
    
    
    
    public void Playbtn()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
    public void BacktoMainMenu()
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                
            }
    
    
    public void QuitApplication()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Stop playing the scene in the editor
            #else
                Application.Quit(); // Quit the application in a build
            #endif
        }
    
     
    
}
