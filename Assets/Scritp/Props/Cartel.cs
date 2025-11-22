using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartel : MonoBehaviour ,IInteractable
{
    [SerializeField]
    private string texto;

    public void InteractuarCon(GameObject jugador)
    {
        NotificationSystem.Instance.ShowMessage(texto,4);
    }
}
