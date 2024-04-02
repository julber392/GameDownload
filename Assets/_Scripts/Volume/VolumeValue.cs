using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSrc.volume = musicVolume;
        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
