using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BirdController _birdController;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highestScoreText;

    private int _playerScore;

    private void OnEnable()
    {
        ScoreTrigger.Triggered += OnScoreCollected;
    }

    private void OnDisable()
    {
        ScoreTrigger.Triggered -= OnScoreCollected;
    }

    private void OnScoreCollected()
    {
        AddScore(1);
    }

    private void Start()
    {
        _highestScoreText.text = $"Highest: {PlayerPrefs.GetInt("highest_score", 0)}";
    }

    public void AddScore(int amount)
    {
        if (!_birdController.IsAlive)
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
