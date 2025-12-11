using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorDeEscena : MonoBehaviour
{
    public void CambiarALaEscena(string nombreDeScena)
    {
        SceneManager.LoadScene(nombreDeScena);
    }
}
