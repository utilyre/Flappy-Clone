using UnityEngine;

public class Deadzone : MonoBehaviour
{
    [SerializeField] private BirdController _birdController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _birdController.Die();
    }
}
