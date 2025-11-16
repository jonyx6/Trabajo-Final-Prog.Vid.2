using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    private AudioSource audioSource;
/*     [SerializeField]
    private AudioClip music;
    [SerializeField]
    private float musicVolume; */

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
        } else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
/*         audioSource.clip = music;
        audioSource.loop = true;
        audioSource.volume = musicVolume;
        audioSource.Play(); */
    }
    public void ReproducirSonido(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
