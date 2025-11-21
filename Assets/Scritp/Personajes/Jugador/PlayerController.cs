using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Atributos))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string layerDeItems;
    private bool tieneLLave = false;
    [SerializeField]
    private string tagDeLLave = "Llave";
    Atributos atributosDelJugador;
    private void Awake()
    {
        IntentarCargarAtributos();
    }
    private void IntentarCargarAtributos()
    {
        atributosDelJugador = GetComponent<Atributos>();
        if (GameManager.Instance != null && GameManager.Instance.tieneAtributos)
        {
            GameManager.Instance.CargarAtributos(atributosDelJugador);
        }
    }
    public void GuardarAtributos()
    {
        GameManager.Instance.GuardarAtributos(atributosDelJugador);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(layerDeItems))
        {
            Item item = other.GetComponent<Item>();
            atributosDelJugador.AumentarAtributo(item.atributo, item.cantidadQueAumenta);
            NotificationSystem.Instance.ShowMessage("+" + item.cantidadQueAumenta + " de " + item.atributo, 1);
            Destroy(item.gameObject);
        }
        if (other.CompareTag("Salida"))
        {
            if (tieneLLave)
            {
                GuardarAtributos();
                other.GetComponent<Salida>().Salir();
            }
            else
            {
                NotificationSystem.Instance.ShowMessage("Necesitas una llave para continuar", 2);
            }

        }
        if (other.CompareTag(tagDeLLave))
        {
            tieneLLave = true;
            NotificationSystem.Instance.ShowMessage("Llave conseguida",1);
            Destroy(other.gameObject);
        }
    }
}
