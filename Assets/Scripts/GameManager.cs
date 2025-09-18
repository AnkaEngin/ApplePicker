using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    
    [Header("Game Settings")]
    public int pointsPerApple = 10;
    
    // Game state variables
    public static GameManager instance;
    private int currentScore = 0;
    private int highScore = 0;
    private int livesLost = 0;
    private bool gameOver = false;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        LoadHighScore();
        UpdateUI();
        UpdateHearts();
    }
    
    // Called when apple is caught by basket
    public void AppleCaught()
    {
        // If game was over, restart it
        if (gameOver)
        {
            RestartAfterGameOver();
        }
        
        currentScore += pointsPerApple;
        
        // Check for new high score
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
        }
        
        UpdateUI();
        Debug.Log("Apple caught! Score: " + currentScore + " | High Score: " + highScore);
    }
    
    // Called when apple hits ground
    public void AppleMissed()
    {
        if (gameOver) return; // Don't lose more lives if already game over
        
        livesLost++;
        UpdateHearts();
        
        Debug.Log("Apple missed! Lives lost: " + livesLost);
        
        // Check for game over (all 3 hearts lost)
        if (livesLost >= 3)
        {
            GameOver();
        }
    }
    
    void GameOver()
    {
        gameOver = true;
        currentScore = 0; // Reset score immediately!
        UpdateUI(); // Update UI immediately to show score = 0
        ClearAllApples();
        
        Debug.Log("Game Over! Score reset to 0. Catch an apple to restart!");
    }
    
    void RestartAfterGameOver()
    {
        gameOver = false;
        livesLost = 0;
        UpdateHearts(); // Restore all hearts
        
        Debug.Log("Game restarted! All hearts restored.");
    }
    
    void ClearAllApples()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples)
        {
            Destroy(apple);
        }
    }
    
    void UpdateHearts()
    {
        if (heart1 != null)
            heart1.gameObject.SetActive(livesLost < 1);
            
        if (heart2 != null)
            heart2.gameObject.SetActive(livesLost < 2);
            
        if (heart3 != null)
            heart3.gameObject.SetActive(livesLost < 3);
    }
    
    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;
            
        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
    }
    
    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }
    
    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}