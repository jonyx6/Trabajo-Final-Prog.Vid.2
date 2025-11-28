using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ParticulasDeJugador : MonoBehaviour
{
    private Animator _animator;
    private void Start() {
        _animator = GetComponent<Animator>();
    }

    public void MostrarParticulasDeVida()
    {
        _animator.SetTrigger("ParticulasDeVida");
    }
    public void MostrarParticulasDeNivel()
    {
        _animator.SetTrigger("ParticulasDeNivel");
    }
}
