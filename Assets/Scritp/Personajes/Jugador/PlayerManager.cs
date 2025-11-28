using System;
using UnityEngine;

[RequireComponent(typeof(Atributos))]
// se encarga de manejar las propiedades del jugador
public class PlayerManager : MonoBehaviour
{
    Atributos atributosDelJugador;
    LevelSystem levelSystemDelJugador;
    Mochila mochilaDelJugador;
    private void Awake()
    {
        CargarDatosDelJugador();
    }
    public void CargarDatosDelJugador()
    {
        IntentarCargarAtributos();
        IntentarCargarLevelSystem();
        IntentarCargarMochila();
    }

    public void GuardarDatosDelJugador()
    {
        GuardarAtributos();
        GuardarLevelSystem();
        GuardarMochila();
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
    
    private void IntentarCargarMochila()
    {
        mochilaDelJugador = GetComponent<Mochila>();
        if (GameManager.Instance != null && GameManager.Instance.tieneMochila)
        {
            GameManager.Instance.CargarMochila(mochilaDelJugador);
        }
    }

    private void GuardarMochila()
    {
        GameManager.Instance.GuardarMochila(mochilaDelJugador);
    }
}
