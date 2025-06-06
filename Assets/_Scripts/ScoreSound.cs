using UnityEngine;

public class ScoreSound : MonoBehaviour
{
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

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
        _audio.Play();
    }
}
