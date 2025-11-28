using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Atributos))]
public class GameManager : MonoBehaviour
{
    public int nivelDelJugador = 1;
    public int nivelActual;
    public static GameManager Instance { get; private set; }
    public GameObject Jugador;

    public Atributos atributosGuardados;
    public bool tieneAtributos = false;

    private int Nivel = 0;
    private float expActual = 0f;
    private float limitDelNivel = 100f;
    public bool tieneLevelSystem = false;

    public bool tieneMochila = false;
    Dictionary<ItemsDeMochila, ItemGuardado> ItemsDeMochilaGuardados;

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

    public void GuardarLevelSystem(LevelSystem levelSystem)
    {
        Nivel = levelSystem.Nivel;
        expActual = levelSystem.expActual;
        limitDelNivel = levelSystem.limitDelNivel;

        tieneLevelSystem = true;
    }
    public void CargarLevelSystem(LevelSystem levelSystem)
    {
        levelSystem.Nivel = Nivel;
        levelSystem.expActual = expActual;
        levelSystem.limitDelNivel = limitDelNivel;
    }

    public void GuardarMochila(Mochila mochila)
    {
        tieneMochila = true;
        ItemsDeMochilaGuardados = mochila.ItemsRecolectados;
    }
    public void CargarMochila(Mochila mochila)
    {
        mochila.ItemsRecolectados = ItemsDeMochilaGuardados;
    }

}
