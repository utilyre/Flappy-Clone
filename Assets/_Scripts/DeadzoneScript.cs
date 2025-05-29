using UnityEngine;

public class DeadzoneScript : MonoBehaviour
{
    [SerializeField] BirdScript Bird;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Bird.Die();
    }
}
