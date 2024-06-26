using UnityEngine;

[RequireComponent(typeof(Sounds))]

public class VolumeByDistance : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _enemy;

    private Sounds _sounds;
    private float _maxDistance = 30;

    private void Start()
    {
        _sounds = GetComponent<Sounds>();
    }

    private void Update()
    {
        float maxValue = 1;
        float distance = Vector2.Distance(_enemy.position, _player.transform.position);
        float volume = Mathf.Clamp(maxValue - distance / _maxDistance, 0, maxValue);

        _sounds.SetValueVolume(volume);
    }
}
