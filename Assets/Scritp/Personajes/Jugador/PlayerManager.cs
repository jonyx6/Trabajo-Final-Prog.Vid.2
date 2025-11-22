using UnityEngine;

[RequireComponent(typeof(Atributos))]
// se encarga de manejar las propiedades del jugador
public class PlayerManager : MonoBehaviour
{
    Atributos atributosDelJugador;
    LevelSystem levelSystemDelJugador;
    private void Awake()
    {
        CargarDatosDelJugador();
    }
    public void CargarDatosDelJugador()
    {
        IntentarCargarAtributos();
        IntentarCargarLevelSystem();
    }
    public void GuardarDatosDelJugador()
    {
        GuardarAtributos();
        GuardarLevelSystem();
    }

    private void IntentarCargarAtributos()
    {
        atributosDelJugador = GetComponent<Atributos>();
        if (GameManager.Instance != null && GameManager.Instance.tieneAtributos)
        {
            GameManager.Instance.CargarAtributos(atributosDelJugador);
        }
    }
    private void GuardarAtributos()
    {
        GameManager.Instance.GuardarAtributos(atributosDelJugador);
    }

    private void IntentarCargarLevelSystem()
    {
        levelSystemDelJugador = GetComponent<LevelSystem>();
        if (GameManager.Instance != null && GameManager.Instance.tieneLevelSystem)
        {
            GameManager.Instance.CargarLevelSystem(levelSystemDelJugador);
        }
    }
    private void GuardarLevelSystem()
    {
        GameManager.Instance.GuardarLevelSystem(levelSystemDelJugador);
    }

}
