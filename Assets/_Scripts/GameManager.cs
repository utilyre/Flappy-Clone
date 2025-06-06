using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BirdController _birdController;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highestScoreText;

    [SerializeField] private float _doubleScoreTimeout = 10;

    private int _playerScore = 0;
    private bool _doubleScore = false;
    private float _doubleScoreTimer = 0;

    private void OnEnable()
    {
        ScoreTrigger.Triggered += OnScoreTriggered;
        DoubleScore.Collected += OnDoubleScoreCollected;
    }

    private void OnDisable()
    {
        ScoreTrigger.Triggered -= OnScoreTriggered;
        DoubleScore.Collected -= OnDoubleScoreCollected;
    }

    private void OnScoreTriggered()
    {
        AddScore(1);
    }

    private void OnDoubleScoreCollected()
    {
        _doubleScore = true;
        AddScore(0); // update score text
    }

    private void Start()
    {
        _highestScoreText.text = $"Highest: {PlayerPrefs.GetInt("highest_score", 0)}";
    }

    private void Update()
    {
        if (_doubleScore)
        {
            _doubleScoreTimer += Time.deltaTime;
            if (_doubleScoreTimer > _doubleScoreTimeout)
            {
                _doubleScoreTimer = 0;
                _doubleScore = false;
                AddScore(0); // update score text
            }
        }
    }

    public void AddScore(int amount)
    {
        if (!_birdController.IsAlive)
        {
            return;
        }

        if (_doubleScore)
        {
            _playerScore += 2 * amount;
        }
        else
        {
            _playerScore += amount;
        }

        int highestScore = PlayerPrefs.GetInt("highest_score", 0);
        if (_playerScore > highestScore)
        {
            highestScore = _playerScore;
            PlayerPrefs.SetInt("highest_score", highestScore);
            PlayerPrefs.Save();
        }

        _highestScoreText.text = $"Highest: {highestScore}";
        if (_doubleScore)
        {
            _scoreText.text = $"2x{_playerScore}";
        }
        else
        {
            _scoreText.text = _playerScore.ToString();
        }
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
