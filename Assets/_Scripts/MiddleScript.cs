using System;
using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    public static event Action ScoreCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreCollected?.Invoke();
    }
}
