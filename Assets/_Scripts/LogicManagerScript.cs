using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    [SerializeField] BirdScript Bird;
    [SerializeField] Text ScoreText;
    [SerializeField] Text HighestScoreText;

    int m_PlayerScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighestScoreText.text = $"Highest: {PlayerPrefs.GetInt("highest_score", 0)}";
    }

    [ContextMenu("Add score")]
    public void AddScore(int amount)
    {
        if (!Bird.IsAlive())
        {
            return;
        }

        m_PlayerScore += amount;
        int highestScore = PlayerPrefs.GetInt("highest_score", 0);
        if (m_PlayerScore > highestScore)
        {
            highestScore = m_PlayerScore;
            PlayerPrefs.SetInt("highest_score", highestScore);
            PlayerPrefs.Save();
        }

        HighestScoreText.text = $"Highest: {highestScore}";
        ScoreText.text = m_PlayerScore.ToString();
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
