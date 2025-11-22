using UnityEngine;

[RequireComponent(typeof(SistemaDeSalud))]
[RequireComponent(typeof(Atributos))]
[RequireComponent(typeof(PlayerManager))]
//se encarga de gestionar las interacciones con otros objetos
public class InterationSystem : MonoBehaviour
{
    [SerializeField]
    private string layerDeInteractuables;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(layerDeInteractuables))
        {
            IInteractable objetoInteractuable = other.GetComponent<IInteractable>();
            objetoInteractuable.InteractuarCon(this.gameObject);
        }
    }
}
