using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterationSystem : MonoBehaviour
{
    [Header(" tag del objeto")]

    public string tagName;

    public HealdSystem hsPersonaje;

    private void Awake()
    {
        hsPersonaje=GetComponent<HealdSystem>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (EsPersonaje_ConTag_(collision, tagName))
        {
            LevelSystem personaje = collision.GetComponentInParent<LevelSystem>();
            hsPersonaje.RecibirUn_(collision.GetComponentInParent<Personaje>().atributos.Pa);
            hsPersonaje.Morir(personaje);
        }
    }

 

    bool EsPersonaje_ConTag_(Collider2D unPersonaje, string unTag)
    {
        return unPersonaje.gameObject.CompareTag(unTag);
    }
}
