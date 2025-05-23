using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int score = 0;
    private int level = 1;
    private int levelUpScore = 10; // Need 10 points to level up

    public Text scoreText;
    public Text levelText;

    private void Awake()
    {
        scoreText.text = "Score: " + score.ToString();
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;

        // Ki?m tra n?u ?? ?i?m ?? lên level
        if (score >= level * levelUpScore)
        {
            IncreaseLevel();
        }

        UpdateUI();
    }

    private void IncreaseLevel()
    {
        level++;
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        if (levelText != null)
        {
            levelText.text = "Level: " + level;
        }
    }

    public int GetLevel()
    {
        return level;
    }

}
