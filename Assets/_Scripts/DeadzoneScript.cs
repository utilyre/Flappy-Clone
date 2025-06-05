using UnityEngine;

public class DeadzoneScript : MonoBehaviour
{
    [SerializeField] private BirdScript _bird;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _bird.Die();
    }
}
