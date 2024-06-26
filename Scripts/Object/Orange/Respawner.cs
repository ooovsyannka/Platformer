using System.Collections;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private Orange _orange;
    [SerializeField] private int _delay;

    private void OnEnable()
    {
        _orange.Died += Spawn;
    }

    private void OnDisable()
    {
        _orange.Died -= Spawn;
    }

    private void Spawn()
    {
        StartCoroutine(Coldown());
    }

    private IEnumerator Coldown()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        yield return wait;

        _orange.gameObject.SetActive(true);
    }
}