using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public BirdScript bird;
    public Text ScoreText;
    public Text HighestScoreText;
    public int PlayerScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighestScoreText.text = $"Highest: {PlayerPrefs.GetInt("highest_score", 0)}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Add score")]
    public void AddScore(int amount)
    {
        if (!bird.isAlive)
        {
            return;
        }

        PlayerScore += amount;
        int highestScore = PlayerPrefs.GetInt("highest_score", 0);
        if (PlayerScore > highestScore)
        {
            highestScore = PlayerScore;
            PlayerPrefs.SetInt("highest_score", highestScore);
            PlayerPrefs.Save();
        }

        HighestScoreText.text = $"Highest: {highestScore}";
        ScoreText.text = PlayerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
