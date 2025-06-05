using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    private LogicManager _logicManager;
    private AudioSource _pointSound;

    private void Start()
    {
        _logicManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LogicManager>();
        _pointSound = GameObject.FindGameObjectWithTag("PointSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _logicManager.AddScore(1);
        _pointSound.Play();
    }
}
