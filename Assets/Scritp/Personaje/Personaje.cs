using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [Header("Sistema de ataque")]
    private AttackSystem asPersonaje;

    [Header("Atributos")]
    public Atributos2 atributos;


    [Header("Sistema de getsion De Vida")]

    private HealdSystem hsPersonaje;


    void Awake()
    {
        
        asPersonaje = GetComponent<AttackSystem>();
        // aPersonaje = GetComponent<Atributos>();
        hsPersonaje = GetComponent<HealdSystem>();

    }
    void Start()
    {
        atributos = GameManager.Instance.AtributosDelJugador;
        // if (!GameManager.Instance.atributos)
        // {

        // }
        // if(aPersonaje != GameManager.Instance.atributos)
        // {
        //     aPersonaje = GameManager.Instance.atributos;
        // }
        // GameManager.Instance.atributos = aPersonaje;
    }
    void OnDestroy()
    {
        Debug.Log("me destruyeron");
    }



}
