using UnityEngine;

public class AmbientSoundZone : MonoBehaviour 
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AmbientSound _ambientSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent(out AmbientListener ambientListener))
        {
            _ambientSound.SetAmbient(_audioClip);
        }
    }
}
