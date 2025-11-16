using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public void PlayClip(AudioClip clip)
    {
        AudioManager.Instance.ReproducirSonido(clip);
    }
}