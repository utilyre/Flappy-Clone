using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField] float Speed = 10;
    [SerializeField] float LeftDeadzone = -30;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Speed * Time.deltaTime * Vector3.left;
        if (transform.position.x <= LeftDeadzone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
