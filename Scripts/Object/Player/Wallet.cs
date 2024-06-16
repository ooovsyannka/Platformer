using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _count;

    public event Action<int> ChangeValue;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Orange coin))
        {
            _count += coin.Collected();

            ChangeValue?.Invoke(_count);
        }
    }
}