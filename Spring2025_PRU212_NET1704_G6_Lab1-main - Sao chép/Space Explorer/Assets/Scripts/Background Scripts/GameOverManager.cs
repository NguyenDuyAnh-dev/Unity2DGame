using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button playAgainButton;
    public Button exitButton;
    void Start()
    {
        // Hiển thị điểm số cuối cùng
        scoreText.text = "Final " + PlayerPrefs.GetString("PlayerScore", "0");

        // Xử lý nút Play Again
        playAgainButton.onClick.AddListener(() => PlayAgain());
        exitButton.onClick.AddListener(QuitGame);
    }
    void QuitGame()
    {
        Debug.Log("Exiting game...");
        //UnityEditor.EditorApplication.isPlaying = false; 
        Application.Quit();
    }
    void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // set player score to 0
}
