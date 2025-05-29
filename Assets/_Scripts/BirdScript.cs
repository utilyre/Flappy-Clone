using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] float FlapStrength = 10.0f;
    [SerializeField] float DieGravity = 10;

    [SerializeField] GameObject GameoverMenu;
    [SerializeField] AudioSource FlapSound;
    [SerializeField] AudioSource DieSound;

    Rigidbody2D m_Rigidbody;
    CircleCollider2D m_Collider;

    bool m_IsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsAlive && Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody.linearVelocity = FlapStrength * Vector2.up;
            FlapSound.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    public void Die()
    {
        GameoverMenu.SetActive(true);
        m_IsAlive = false;
        m_Rigidbody.gravityScale = DieGravity;
        m_Collider.enabled = false;
        DieSound.Play();
    }

    // TODO: This is an anti-pattern, please remove when possible
    public bool IsAlive()
    {
        return m_IsAlive;
    }
}
