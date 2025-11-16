using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SistemaDeSalud))]
public class InterationSystem : MonoBehaviour
{
    [Header(" tag del objeto")]

    public string tagName;

    private SistemaDeSalud hsPersonaje;

    private void Awake()
    {
        hsPersonaje=GetComponent<SistemaDeSalud>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (EsPersonaje_ConTag_(collision, tagName))
        {
            Atributos personaje = collision.GetComponentInParent<Atributos>();
            hsPersonaje.Recibir_(1/* collision.GetComponentInParent<Personaje>().atributos */);
            //hsPersonaje.Morir(personaje);
        }
    }

 

    bool EsPersonaje_ConTag_(Collider2D unPersonaje, string unTag)
    {
        return unPersonaje.gameObject.CompareTag(unTag);
    }
}
