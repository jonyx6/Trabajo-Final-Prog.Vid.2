using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundPlayer : SoundPlayer
{
    [Header("Sonidos de Ataque")]
    [SerializeField] private AudioClip atack1Sound;
    [SerializeField] private AudioClip atack2Sound;
    [SerializeField] private AudioClip especialAtackSound;

    [Header("Sonidos de Estado")]
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;

    [Header("Sonidos de Movimiento")]
    [SerializeField] private AudioClip[] walkSounds;

    public void PlayAtack1Sound()
    {
        PlayClip(atack1Sound);
    }

    public void PlayAtack2Sound()
    {
        PlayClip(atack2Sound);
    }

    public void PlayEspecialAtackSound()
    {
        PlayClip(especialAtackSound);
    }

    public void PlayHurtSound()
    {
        PlayClip(hurtSound);
    }

    public void PlayDeathSound()
    {
        PlayClip(deathSound);
    }

    public void PlayWalkSound()
    {
        if (walkSounds.Length == 0) return;

        AudioClip clip = walkSounds[Random.Range(0, walkSounds.Length)];
        PlayClip(clip);
    }
}