using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    [SerializeField] private BirdScript _bird;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highestScoreText;

    private int _playerScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _highestScoreText.text = $"Highest: {PlayerPrefs.GetInt("highest_score", 0)}";
    }

    public void AddScore(int amount)
    {
        if (!_bird.IsAlive())
        {
            return;
        }

        _playerScore += amount;
        int highestScore = PlayerPrefs.GetInt("highest_score", 0);
        if (_playerScore > highestScore)
        {
            highestScore = _playerScore;
            PlayerPrefs.SetInt("highest_score", highestScore);
            PlayerPrefs.Save();
        }

        _highestScoreText.text = $"Highest: {highestScore}";
        _scoreText.text = _playerScore.ToString();
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
