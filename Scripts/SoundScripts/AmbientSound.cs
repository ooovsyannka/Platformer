using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipForest;

    private void Start()
    {
        SetAmbient(_audioClipForest);
    }

    public void SetAmbient(AudioClip clip)
    {
        _audioSource.clip = clip;

        if (_audioSource.isPlaying == false)
            _audioSource.Play();
    }
}
