using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Atributos))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string layerDeItems;
    Atributos atributosDelJugador;
    private void Start()
    {
        atributosDelJugador = GetComponent<Atributos>();
        if (GameManager.Instance.tieneAtributos)
        {
            atributosDelJugador.CopiarDesde(GameManager.Instance.atributosGuardados);
        }

        GameManager.Instance.tieneAtributos = true;
        GameManager.Instance.atributosGuardados.CopiarDesde(atributosDelJugador);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer(layerDeItems))
        {
            Item item = other.GetComponent<Item>();
            atributosDelJugador.AumentarAtributo(item.atributo,item.cantidadQueAumenta);
        }
    }
}
