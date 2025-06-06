using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float _flapStrength = 20;
    [SerializeField] private float _dieGravity = 20;

    [SerializeField] private GameObject _gameoverMenu;
    [SerializeField] private AudioSource _flapSound;
    [SerializeField] private AudioSource _dieSound;

    private Rigidbody2D _rigidbody;
    private CircleCollider2D _collider;
    private Shooter _shooter;

    public bool IsAlive { get; private set; } = true;

    private void OnEnable()
    {
        GunPowerUp.Collected += OnGunCollected;
    }

    private void OnDisable()
    {
        GunPowerUp.Collected -= OnGunCollected;
    }

    private void OnGunCollected()
    {
        _shooter.enabled = true;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        if (IsAlive && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.linearVelocity = _flapStrength * Vector2.up;
            _flapSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    public void Die()
    {
        _gameoverMenu.SetActive(true);
        _shooter.enabled = false;
        IsAlive = false;
        _rigidbody.gravityScale = _dieGravity;
        _collider.enabled = false;
        _dieSound.Play();
    }
}
