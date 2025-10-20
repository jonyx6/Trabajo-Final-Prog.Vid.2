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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (EsElEnemigo(collision))
        {
            AtacarAl_(collision);
        }
    }

    void AtacarAl_(Collider2D enemigo)
    {
        enemigo.GetComponent<HealdSystem>().RecibirUn_(aPersonaje.Pa);
    }

    bool EsElEnemigo(Collider2D unPersonaje)
    {
        return unPersonaje.gameObject.CompareTag("Enemigo");
    }

    private void Update()
    {
        Debug.Log("la posicion  actual de " + aPersonaje.Nombre + " es "+ transform.position );
    }


}
