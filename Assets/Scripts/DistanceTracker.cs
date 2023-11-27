using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    [SerializeField] public Transform player;      // Player's transform
    [SerializeField] public TextMeshProUGUI distanceText;     // Reference to the UI Text element to display distance

    [SerializeField] public float distanceTraveled;

    public BackgroundScroller backgroundScroller;
    public bool gameRunning = true; // Ensure the game is initially running
    
    private float _timecounter = 0;

    void Awake()
    {
        backgroundScroller = FindObjectOfType<BackgroundScroller>();
        distanceTraveled = 0f; // Initialize distance to 0
        UpdateDistanceText(); // Update the UI text initially
    }

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned to DistanceTracker.");
            return;
        }
    }

    public void ResetDistance()
    {
        distanceTraveled = 0f;
        _timecounter = 0f;
        gameRunning = false;
        UpdateDistanceText(); // Update the UI text after resetting distance
    }

    void Update()
    {
        // Calculate the distance only if the game is running
        if (gameRunning)
        {
            CalculateDistance();
        }

        
    }

    // Calculate the distance traveled based on the player's position
    void CalculateDistance()
    {
        if (player != null && backgroundScroller != null)
        {
            _timecounter += 0.1f; 
            distanceTraveled = Mathf.Abs(_timecounter * backgroundScroller.scrollSpeed);
            UpdateDistanceText(); // Update the UI text after calculating distance
        }
    }

    // Update the Text UI element to display the distance
    void UpdateDistanceText()
    {
        distanceText.SetText("Distance: " + distanceTraveled.ToString("F2") + " m");
        //distanceText.text = "Distance: " + distanceTraveled.ToString("F2") + " m";
    }
}