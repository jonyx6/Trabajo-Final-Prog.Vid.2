using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioClip music;
    [SerializeField]
    private float musicVolume;

    public static AudioManager Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }
    public void ReproducirSonido(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
