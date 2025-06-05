using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    private LogicManagerScript _logic;
    private AudioSource _pointSound;

    private void Start()
    {
        _logic = GameObject.FindGameObjectWithTag("GameController").GetComponent<LogicManagerScript>();
        _pointSound = GameObject.FindGameObjectWithTag("PointSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _logic.AddScore(1);
        _pointSound.Play();
    }
}
