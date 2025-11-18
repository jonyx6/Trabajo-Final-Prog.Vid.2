using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Atributos))]
public class GameManager : MonoBehaviour
{
    public int nivelDelJugador = 1;
    public static GameManager Instance{ get; private set;}
    public GameObject Jugador;

    public Atributos atributosGuardados;
    public bool tieneAtributos = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        atributosGuardados = GetComponent<Atributos>();
    }

    public void GuardarAtributos(Atributos atributos)
    {
        atributosGuardados.CopiarDesde(atributos);
        tieneAtributos = true;
    }
    public void CargarAtributos(Atributos atributos)
    {
        atributos.CopiarDesde(atributosGuardados);
    }
}
