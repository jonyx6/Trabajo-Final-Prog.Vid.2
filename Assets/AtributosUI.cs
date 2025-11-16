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
    private Atributos atributosAMostrar;
    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            panelDeAtributos.SetActive(!panelDeAtributos.activeInHierarchy);
            AsignarAtributos();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            textTopeNivel.text = "1";
        }
    }
    private void AsignarAtributos()
    {
        textPoderAtaque.text = atributosAMostrar.Pa.ToString();
        textPoderDefensa.text = atributosAMostrar.Pd.ToString();
        textVida.text = atributosAMostrar.Vida+"/"+atributosAMostrar.VidaMaxima;
        textVelocidad.text = atributosAMostrar.Velocidad.ToString("F1");

        // texto niveles 
        /* textNroNivel.text = atributosAMostrar.Nivel.ToString();
        textExpActual.text = atributosAMostrar.expActual.ToString("F1");
        textTopeNivel.text =  atributosAMostrar.limitDelNivel.ToString("F1");  */
    }

}
