using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
    [SerializeField]
    private string nextLevel;
    public void Salir()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
