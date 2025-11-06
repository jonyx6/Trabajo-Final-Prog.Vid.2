using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackSystem : MonoBehaviour
{
    private Animator animPersonaje;
    void Start()
    {
        animPersonaje = GetComponent<Animator>();
    }
    public void AtaqueSimple()
    {
        animPersonaje.SetTrigger("isAtacking");
    }
    public void AtaqueEspecial()
    {
        animPersonaje.SetTrigger("isEspecialAtacking");
    }

}
