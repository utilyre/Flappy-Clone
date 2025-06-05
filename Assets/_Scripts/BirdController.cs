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

    private bool _isAlive = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (_isAlive && Input.GetKeyDown(KeyCode.Space))
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
        _isAlive = false;
        _rigidbody.gravityScale = _dieGravity;
        _collider.enabled = false;
        _dieSound.Play();
    }

    // TODO: This is an anti-pattern, please remove when possible
    public bool IsAlive()
    {
        return _isAlive;
    }
}
