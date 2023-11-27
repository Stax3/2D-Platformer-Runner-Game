using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]  public  int score = 5000;
    public TextMeshProUGUI scoreText;
    private string scoreKey = "PlayerScore"; // Key for PlayerPrefs

    private bool _purchased1 = false;
    private bool _purchased2 = false;
    private bool _purchased3 = false;
    private bool _purchased4 = false;
    private bool _purchased5 = false;
    private bool _purchased6 = false;
    
    
    
    void Start()
    {
        // Load the score when the game starts
        if (PlayerPrefs.HasKey(scoreKey))
        {
            score = PlayerPrefs.GetInt(scoreKey);
            UpdateScore(0); // Update the displayed score
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        Debug.Log("Score: " + score);

        // Save the score in PlayerPrefs
        PlayerPrefs.SetInt(scoreKey, score);
        PlayerPrefs.Save(); // Save the PlayerPrefs immediately

        if (scoreText != null)
        {
            scoreText.text = "" + score;
        }
    }


    
        public void Buy1stItem()  //price = 1000
        {
            while (_purchased1 == false)
            {
                if (score >= 500) // Ensure sufficient score
                {
                    score -= 500;
                    UpdateScore(-500); // Update the displayed score

                    // Perform the purchase action
                    Debug.Log("Item purchased successfully.");
                    
                }
                else
                {
                    Debug.Log("Insufficient score to purchase.");
                }
                _purchased1 = true;
            }
            
        }
        
        public void Buy2ndItem()  //price = 1500
        {
            while (_purchased2 == false)
            {
                if (score >= 750) // Ensure sufficient score
                {
                    score -= 750;
                    UpdateScore(-750); // Update the displayed score

                    // Perform the purchase action
                    Debug.Log("Item purchased successfully.");
                    
                }
                else
                {
                    Debug.Log("Insufficient score to purchase.");
                }
                _purchased2 = true;
            }
            
        }
        
        public void Buy3rdItem()  //price = 2000
        {
            while (_purchased3 == false)
            {
                if (score >= 1000) // Ensure sufficient score
                {
                    score -= 1000;
                    UpdateScore(-1000); // Update the displayed score

                    // Perform the purchase action
                    Debug.Log("Item purchased successfully.");
                    
                }
                else
                {
                    Debug.Log("Insufficient score to purchase.");
                }
                _purchased3 = true;
            }
            
        }
        
        public void Buy4thItem()  //price = 2500
        {
            while (_purchased4 == false)
            {
                if (score >= 1250) // Ensure sufficient score
                {
                    score -= 1250;
                    UpdateScore(-1250); // Update the displayed score

                    // Perform the purchase action
                    Debug.Log("Item purchased successfully.");
                    
                }
                else
                {
                    Debug.Log("Insufficient score to purchase.");
                }
                _purchased4 = true;
            }
            
        }

        public void Buy5thItem() //price = 3000
        {
            while (_purchased5 == false)
            {
                if (score >= 1500) // Ensure sufficient score
                {
                    score -= 1500;
                    UpdateScore(-1500); // Update the displayed score

                    // Perform the purchase action
                    Debug.Log("Item purchased successfully.");

                }
                else
                {
                    Debug.Log("Insufficient score to purchase.");
                }

                _purchased5 = true;
            }
        }

        public void Buy6thItem()  //price = 3500
            {
                while (_purchased6 == false)
                {
                    if (score >= 1750) // Ensure sufficient score
                    {
                        score -= 1750;
                        UpdateScore(-1750); // Update the displayed score

                        // Perform the purchase action
                        Debug.Log("Item purchased successfully.");
                    
                    }
                    else
                    {
                        Debug.Log("Insufficient score to purchase.");
                    }
                    _purchased6 = true;
                }
            
            }
            
        
    
}