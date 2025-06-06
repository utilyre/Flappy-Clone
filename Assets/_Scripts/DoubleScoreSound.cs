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
        DoubleScore.Collected += OnDoubleScoreCollected;
    }

    private void OnDisable()
    {
        DoubleScore.Collected -= OnDoubleScoreCollected;
    }

    private void OnDoubleScoreCollected()
    {
        _audio.Play();
    }
}
