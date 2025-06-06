using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed = 80;
    [SerializeField] private float _deadzone = 30;

    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rigidbody.linearVelocity = _speed * Vector2.right;
        if (_rigidbody.position.x >= _deadzone)
        {
            Destroy(gameObject);
        }
    }
}
