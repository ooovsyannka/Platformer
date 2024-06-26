using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Orange : MonoBehaviour
{
    [SerializeField] private Sounds _sounds;
    [SerializeField] private OrangeAnimation _animation;

    private State _state;
    private int _maxCount = 10;
    private bool _isDie;

    public event Action Died;

    private void OnEnable()
    {
        _isDie = false;
        _state = State.AnyState;
    }

    public int Collected()
    {
        _isDie = true;
        _state = State.Die;
        _sounds.PlaySound(_state);
        _animation.PlayAnimation(_isDie);

        StartCoroutine(TimeToDie());

        return _maxCount;
    }

    private IEnumerator TimeToDie()
    {
        float delay = 0.5f;

        yield return new WaitForSeconds(delay);

        Died?.Invoke();
        gameObject.SetActive(false);
    }
}
