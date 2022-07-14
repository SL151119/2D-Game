using UnityEngine;
public class MusicMenu : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
