using UnityEngine;

public class DeadzoneScript : MonoBehaviour
{
    public BirdScript bird;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bird.Die();
    }
}
