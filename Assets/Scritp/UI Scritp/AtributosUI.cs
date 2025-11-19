using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AtributosUI : MonoBehaviour
{
    [Header("Panel de Atributos")]
    [SerializeField] 
    private GameObject panelDeAtributos;

    [Header("textos de los atributos")]

    [SerializeField] 
    private TextMeshProUGUI textPoderAtaque;
    [SerializeField] 
    private TextMeshProUGUI textVida;
    [SerializeField] 
    private TextMeshProUGUI textPoderDefensa;
    [SerializeField] 
    private TextMeshProUGUI textVelocidad;

    [Header("Texto De Los Niveles")]

    [SerializeField] 
    private TextMeshProUGUI textNroNivel;
    [SerializeField] 
    private TextMeshProUGUI textExpActual;
    [SerializeField] 
    private TextMeshProUGUI textTopeNivel;

    [SerializeField] 
    private Atributos atributosDelJugador;
    [SerializeField] 
    private LevelSystem levelSystem;

    public void ObtenerInformacionDeJugador()
    {
        atributosDelJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Atributos>();
        levelSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>();
    }
    private void Start() {
        ObtenerInformacionDeJugador();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            panelDeAtributos.SetActive(!panelDeAtributos.activeInHierarchy);
            AsignarAtributos();
        }
    }
    private void AsignarAtributos()
    {
        textPoderAtaque.text = atributosDelJugador.Pa.ToString();
        textPoderDefensa.text = atributosDelJugador.Pd.ToString();
        textVida.text = atributosDelJugador.Vida+"/"+atributosDelJugador.VidaMaxima;
        textVelocidad.text = atributosDelJugador.Velocidad.ToString("F1");

        // texto niveles 
        textNroNivel.text = levelSystem.Nivel.ToString();
        textExpActual.text = levelSystem.expActual.ToString("F1");
        textTopeNivel.text =  levelSystem.limitDelNivel.ToString("F1"); 
    }

}
