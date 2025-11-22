using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour , IInteractable
{
    [SerializeField]
    private string nextLevel;

    public void InteractuarCon(GameObject jugador)
    {
        if (jugador.GetComponent<Mochila>().tieneLLave)
        {
            jugador.GetComponent<PlayerManager>().GuardarDatosDelJugador();
            Salir();
        }
        else
        {
            NotificationSystem.Instance.ShowMessage("Necesitas una llave para continuar", 2);
        }
    }

    public void Salir()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
