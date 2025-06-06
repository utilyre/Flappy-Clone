using System;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public static event Action Triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Triggered?.Invoke();
    }
}
