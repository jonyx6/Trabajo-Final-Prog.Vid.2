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
        if (EsPersonaje_ConTag_(collision,"Espada"))
        {
            AtacarAl_(collision);
        }
    }

    void AtacarAl_(Collider2D enemigo)
    {
        enemigo.GetComponent<HealdSystem>().RecibirUn_(aPersonaje.Pa);
    }

    bool EsPersonaje_ConTag_(Collider2D unPersonaje,string unTag)
    {
        return unPersonaje.gameObject.CompareTag(unTag);
    }

}
