using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;

public class ItemRecolectable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemsDeMochila tipoDeItem;
    public void InteractuarCon(GameObject jugador)
    {
        jugador.GetComponent<Mochila>().AgregarItemDeTipo(tipoDeItem);
        NotificationSystem.Instance.ShowMessage("has conseguido una " + tipoDeItem,1);
        Destroy(gameObject);
   
    }
}
