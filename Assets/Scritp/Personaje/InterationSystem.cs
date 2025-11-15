using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealdSystem))]
public class InterationSystem : MonoBehaviour
{
    [Header(" tag del objeto")]

    public string tagName;

    private HealdSystem hsPersonaje;

    private void Awake()
    {
        hsPersonaje=GetComponent<HealdSystem>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (EsPersonaje_ConTag_(collision, tagName))
        {
            Personaje personaje = collision.GetComponentInParent<Personaje>();
            hsPersonaje.RecibirUn_(1/* collision.GetComponentInParent<Personaje>().atributos */);
            //hsPersonaje.Morir(personaje);
        }
    }

 

    bool EsPersonaje_ConTag_(Collider2D unPersonaje, string unTag)
    {
        return unPersonaje.gameObject.CompareTag(unTag);
    }
}
