using UnityEngine;

[RequireComponent(typeof(SistemaDeSalud))]
[RequireComponent(typeof(Atributos))]
[RequireComponent(typeof(PlayerManager))]
//se encarga de gestionar las interacciones con otros objetos
public class InterationSystem : MonoBehaviour
{
    [SerializeField]
    private string layerDeItems;
    private bool tieneLLave = false;
    [SerializeField]
    private string tagDeLLave = "Llave";
    PlayerManager playerManager;
    Atributos playerAtributos;
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        playerAtributos = GetComponent<Atributos>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(layerDeItems))
        {
            Item item = other.GetComponent<Item>();
            InteractuarConItem(item);
        }

        if (other.CompareTag("Salida"))
        {
            Salida salida = other.GetComponent<Salida>();
            InteratuarConSalida(salida);
        }

        if (other.CompareTag(tagDeLLave))
        {
            InteractuarConLLave(other.gameObject);
        }
    }
    private void InteractuarConItem(Item item)
    {
        playerAtributos.AumentarAtributo(item.atributo, item.cantidadQueAumenta);
        NotificationSystem.Instance.ShowMessage("+" + item.cantidadQueAumenta + " de " + item.atributo, 1);
        Destroy(item.gameObject);
    }
    private void InteractuarConLLave(GameObject llave)
    {
        tieneLLave = true;
        NotificationSystem.Instance.ShowMessage("Llave conseguida", 1);
        Destroy(llave);
    }
    private void InteratuarConSalida(Salida salida)
    {
        if (tieneLLave)
        {
            playerManager.GuardarDatosDelJugador();
            salida.Salir();
        }
        else
        {
            NotificationSystem.Instance.ShowMessage("Necesitas una llave para continuar", 2);
        }
    }
}
