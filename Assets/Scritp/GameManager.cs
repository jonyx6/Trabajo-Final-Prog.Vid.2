using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Atributos2 atributosBaseDelJugador;
    public int nivelDelJugador = 1;
    public static GameManager Instance{ get; private set;}
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
    }
    public Atributos2 AtributosDelJugador
    {
        get { return atributosBaseDelJugador; }
    }
}
