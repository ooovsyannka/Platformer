using System.Collections.Generic;
using UnityEngine;

public class OrangeSpawner : MonoBehaviour
{
    [SerializeField] private List<OrangeHolder> _pool;
    [SerializeField] private OrangeHolder _prefab;
    [SerializeField] private List<Transform> _pointForSpawn;

    private int _currentPosition = 0;

    private void Start()
    {
        _pool = new List<OrangeHolder>();

        for (int i = 0; i < _pointForSpawn.Count; i++)
        {
            OrangeHolder currentOrange = Instantiate(_prefab);
            _pool.Add(currentOrange);
            currentOrange.transform.position = _pointForSpawn[_currentPosition].position;
            currentOrange.gameObject.SetActive(true);
            _currentPosition = (_currentPosition + 1) % _pointForSpawn.Count;
        }
    }
}