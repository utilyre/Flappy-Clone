using UnityEngine;

public class DoubleScoreSound : MonoBehaviour
{
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        DoubleScorePowerUp.Collected += OnDoubleScoreCollected;
    }

    private void OnDisable()
    {
        DoubleScorePowerUp.Collected -= OnDoubleScoreCollected;
    }

    private void OnDoubleScoreCollected()
    {
        _audio.Play();
    }
}
