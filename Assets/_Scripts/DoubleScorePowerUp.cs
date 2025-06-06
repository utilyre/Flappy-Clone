using System;
using UnityEngine;

public class DoubleScorePowerUp : MonoBehaviour
{
    public static event Action Collected;

    // TODO: these values are duplicated between here and PipeController
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _leftDeadzone = -30;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Collected?.Invoke();
        Destroy(gameObject);
        Debug.Log("DoubleScore destroyed by trigger");
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = _speed * Vector3.left;
        if (_rigidbody.position.x <= _leftDeadzone)
        {
            Destroy(gameObject);
            Debug.Log("DoubleScore destroyed by deadzone");
        }
    }
}
