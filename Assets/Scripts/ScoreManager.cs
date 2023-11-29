using System;
using UnityEngine;
using TMPro;

[Serializable]
public class PlayerData
{
    [SerializeField]public int score = 50000;
    public bool[] purchased = new bool[6] {false, false, false, false, false, false};

}
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private PlayerData playerData;
    private string dataFileName = "playerData.dat";

    void Start()
    {
        LoadData();
        UpdateScore(0);
    }

    public void UpdateScore(int addScore)
    {
        playerData.score += addScore;
        Debug.Log("Score: " + playerData.score);

        SaveData();

        if (scoreText != null)
        {
            scoreText.text = playerData.score.ToString();
        }
    }

    //TODO: Score manager should just mange score, this function should not be a part of this class
    public void BuyItem(int price, ref bool purchasedFlag)
    {
        if (!purchasedFlag && playerData.score >= price)
        {
            Debug.Log("Item purchased successfully.");
            playerData.score -= price;
            UpdateScore(0); // Update the displayed score
            purchasedFlag = true;
        }
        else if (!purchasedFlag && playerData.score < price)
        {
            Debug.Log("Insufficient score to purchase. Current Score: " + playerData.score + ", Required: " + price);
            
            
            

        }
        else
        {
            Debug.Log("Item already purchased.");
        }
    }


    public void Buy1stItem()
    {
        BuyItem(500, ref playerData.purchased[0]);
        Debug.Log("purchased flag " + playerData.purchased[0]);
    }

    public void Buy2ndItem()
    {
        BuyItem(1500, ref playerData.purchased[1]);
        Debug.Log("purchased flag " + playerData.purchased[1]);
    }
    
    public void Buy3rdItem()
    {
        BuyItem(2000, ref playerData.purchased[2]);
        Debug.Log("purchased flag " + playerData.purchased[2]);
    }

    public void Buy4thItem()
    {
        BuyItem(2500, ref playerData.purchased[3]);
        Debug.Log("purchased flag " + playerData.purchased[3]);
        
    }

    public void Buy5thItem()
    {
        BuyItem(3000, ref playerData.purchased[4]);
        Debug.Log("purchased flag " + playerData.purchased[4]);
    }


    public void Buy6thItem()
    {
        BuyItem(3500, ref playerData.purchased[5]);
        Debug.Log("purchased flag " + playerData.purchased[5]);
    }
   

    private void SaveData()
    {
        string filePath = Application.persistentDataPath + "/" + dataFileName;
        string jsonData = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText(filePath, jsonData);
    }

    private void LoadData()
    {
        string filePath = Application.persistentDataPath + "/" + dataFileName;
        if (System.IO.File.Exists(filePath))
        {
            string jsonData = System.IO.File.ReadAllText(filePath);
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        }
        else
        {
            playerData = new PlayerData();
        }
    }
}
