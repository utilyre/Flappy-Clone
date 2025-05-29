using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    LogicManagerScript m_Logic;
    AudioSource m_PointSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Logic = GameObject.FindGameObjectWithTag("GameController").GetComponent<LogicManagerScript>();
        m_PointSound = GameObject.FindGameObjectWithTag("PointSound").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        m_Logic.AddScore(1);
        m_PointSound.Play();
    }
}
