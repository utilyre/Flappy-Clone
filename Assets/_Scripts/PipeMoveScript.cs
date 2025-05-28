using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float speed = 10.0f;
    public float deadzone = -30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
        if (transform.position.x <= deadzone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
