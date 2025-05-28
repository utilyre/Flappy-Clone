using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    public LogicManagerScript logic;
    public AudioSource pointSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("GameController").GetComponent<LogicManagerScript>();
        pointSound = GameObject.FindGameObjectWithTag("PointSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        logic.AddScore(1);
        pointSound.Play();
    }
}
