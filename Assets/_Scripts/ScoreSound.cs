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
        MiddleScript.ScoreCollected += OnScoreCollected;
    }

    private void OnDisable()
    {
        MiddleScript.ScoreCollected -= OnScoreCollected;
    }

    private void OnScoreCollected()
    {
        _audio.Play();
    }
}
