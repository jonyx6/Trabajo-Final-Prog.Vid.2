using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [Header("Panel de Inventario")]
    public GameObject Inventario;

    [Header("Panel de Atributos")]
    public GameObject Atributos;



    [Header("Botones de habilidades")]
    public Image boton1; // R
    public Image boton2; // E
    public Image boton3; // W
    public Image boton4; // Q

    [Header("estado de  atributos")]
   
    private bool atributosActivado = false;

    [Header("recuperacion de cada boton ")]
    public float recargaBoton1 = 0.1f;
    public float recargaBoton2 = 3f;
    public float recargaBoton3 = 6f;
    public float recargaBoton4 = 10f;

    [Header("Atributos Del Personaje")]
    public LevelSystem lsPersonaje;

    [Header("textos de los atributos")]

    public TextMeshProUGUI textPoderAtaque;
    public TextMeshProUGUI textVida;
    public TextMeshProUGUI textPoderDefensa;
    public TextMeshProUGUI textVelocidad;

    [Header("Texto De Los Niveles")]

    public TextMeshProUGUI textNroNivel;
    public TextMeshProUGUI textExpActual;
    public TextMeshProUGUI textTopeNivel;



    private void Awake()
    {
        // Asegurar que los botones empiecen llenos
        boton1.fillAmount = 1f;
        boton2.fillAmount = 1f;
        boton3.fillAmount = 1f;
        boton4.fillAmount = 1f;

    
        

       
    }

    private void Update()
    {
       
        ActivarAtributos();

        CargaBoton(boton1, KeyCode.R, recargaBoton1);
        CargaBoton(boton2, KeyCode.E, recargaBoton2);
        CargaBoton(boton3, KeyCode.W, recargaBoton3);
        CargaBoton(boton4, KeyCode.Q, recargaBoton4);

        
    }





    void ActivarAtributos()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            atributosActivado = !atributosActivado;
            Atributos.SetActive(atributosActivado);

            // Activar hijo expl�citamente si existe
            Transform hijo = Atributos.transform.Find("atributos");
            if (hijo != null)
                hijo.gameObject.SetActive(atributosActivado);

            Debug.Log("Se activaron los atributos");
        }

        ActualizarAtributos();
    }

    void CargaBoton(Image unBoton, KeyCode tecla, float duracion)
    {
        

        if (Input.GetKeyDown(tecla) && unBoton.fillAmount == 1f)
        {
            Debug.Log("Tecla presionada: " + tecla);
            unBoton.fillAmount = 0f;
            StartCoroutine(RecargarBoton(unBoton, duracion));
        }
    }

    IEnumerator RecargarBoton(Image unBoton, float duracion)
    {
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            unBoton.fillAmount = tiempo / duracion;
            
            yield return null;
        }
        unBoton.fillAmount = 1f;
        
    }

    // textos atributos

    void ActualizarAtributos()
    {
        /*Atributos2 atributos = GameManager.Instance.AtributosDelJugador;
        textPoderAtaque.text = atributos.Pa.ToString("F1");
        textPoderDefensa.text = atributos.Pd.ToString("F1");
        textVida.text = atributos.Vida.ToString("F1");
        textVelocidad.text = atributos.Velocidad.ToString("F1");

        // texto niveles 
        textNroNivel.text = lsPersonaje.Nivel.ToString();
        textExpActual.text = lsPersonaje.expActual.ToString("F1");
        textTopeNivel.text =  lsPersonaje.limitDelNivel.ToString("F1"); */

    }
}
