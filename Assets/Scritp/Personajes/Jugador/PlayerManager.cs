using UnityEngine;

[RequireComponent(typeof(Atributos))]
// se encarga de manejar las propiedades del jugador
public class PlayerManager : MonoBehaviour
{
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
}
