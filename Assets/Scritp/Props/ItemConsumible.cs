using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConsumible : MonoBehaviour, IInteractable
{
    public TipoDeAtributo atributo;
    public float cantidadQueAumenta;
    public void InteractuarCon(GameObject jugador)
    {
        Atributos playerAtributos = jugador.GetComponent<Atributos>();
        playerAtributos.AumentarAtributo(atributo, cantidadQueAumenta);
        NotificationSystem.Instance.ShowMessage("+" + cantidadQueAumenta + " de " + atributo, 1);
        Destroy(gameObject);
    }
}
