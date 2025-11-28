
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuInicial : MonoBehaviour
{

    public void EmpezarJuego()
    {
        // Cambi� "Nivel1" por el nombre de tu escena
        SceneManager.LoadScene("Nivel 1");
        GameManager.Instance.nivelActual = "Nivel 1";
    }

    public void SalirDelJuego()
    {
       Application.Quit();

        Debug.Log("El Juego Se Cerro");
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(GameManager.Instance.nivelActual);
    }
}
