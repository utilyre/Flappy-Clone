using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public CircleCollider2D myCollider;
    public float flapStrength = 10.0f;
    public GameObject gameOverMenu;
    public bool isAlive = true;
    public float dieGravity = 10;
    public AudioSource flapSound;
    public AudioSource dieSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = flapStrength * Vector2.up;
            flapSound.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    public void Die()
    {
        gameOverMenu.SetActive(true);
        isAlive = false;
        myRigidbody.gravityScale = dieGravity;
        myCollider.enabled = false;
        dieSound.Play();
    }
}
