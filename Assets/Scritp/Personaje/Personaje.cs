using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [Header("Sistema de ataque")]
    private AttackSystem asPersonaje;

    [Header("Atributos")]
    private Atributos aPersonaje;

    [Header("Sistema de getsion De Vida")]

    private HealdSystem hsPersonaje;

    
     void Awake()
    {
        asPersonaje = GetComponent<AttackSystem>();
        aPersonaje = GetComponent<Atributos>();
        hsPersonaje = GetComponent <HealdSystem>();
      
    }



}
