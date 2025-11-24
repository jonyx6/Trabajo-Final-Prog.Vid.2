using UnityEngine;

public class Llave : MonoBehaviour, IInteractable
{
    
    public void InteractuarCon(GameObject jugador)
    {
        NotificationSystem.Instance.ShowMessage("Llave conseguida", 1);
        jugador.GetComponent<Mochila>().tieneLLave = true;
        Destroy(gameObject);
    }
}
