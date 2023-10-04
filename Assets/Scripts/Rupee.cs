using System;
using UnityEngine;

public class Rupee : MonoBehaviour
{
    public event Action<Rupee> OnCollected; 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollected?.Invoke(this);
        }
    }
}
