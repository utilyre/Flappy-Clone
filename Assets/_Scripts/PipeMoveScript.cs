using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _leftDeadzone = -30;

    private void FixedUpdate()
    {
        transform.position += _speed * Time.deltaTime * Vector3.left;
        if (transform.position.x <= _leftDeadzone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
