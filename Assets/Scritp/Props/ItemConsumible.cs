using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConsumible : MonoBehaviour, IInteractable
{
    [SerializeField]
    private TipoDeAtributo atributo;
    [SerializeField]
    private float cantidadQueAumenta;
    [SerializeField]
    private AudioClip sonidoAlConsumir;
    public void InteractuarCon(GameObject jugador)
    {
        Atributos playerAtributos = jugador.GetComponent<Atributos>();
        playerAtributos.AumentarAtributo(atributo, cantidadQueAumenta);
        NotificationSystem.Instance.ShowMessage("+" + cantidadQueAumenta + " de " + atributo, 1);
        AudioManager.Instance.ReproducirSonido(sonidoAlConsumir);
        Destroy(gameObject);
    }
}
