using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _leftDeadzone = -30;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = _speed * Vector2.left;
        if (_rigidbody.position.x <= _leftDeadzone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
