using System.Collections;
using System.Collections.Generic;
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

    private bool inventarioActivado = false;
    private bool atributosActivado = false;

    private void Start()
    {
        // Asegurar que los botones empiecen llenos
        boton1.fillAmount = 1f;
        boton2.fillAmount = 1f;
        boton3.fillAmount = 1f;
        boton4.fillAmount = 1f;
    }

    private void Update()
    {
        ActivarInventario();
        ActivarAtributos();

        CargaBoton(boton1, KeyCode.R, 2f);
        CargaBoton(boton2, KeyCode.E, 2f);
        CargaBoton(boton3, KeyCode.W, 2f);
        CargaBoton(boton4, KeyCode.Q, 2f);
    }

    void ActivarInventario()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventarioActivado = !inventarioActivado;
            Inventario.SetActive(inventarioActivado);

            // Activar hijo explícitamente si existe
            Transform hijo = Inventario.transform.Find("Inventario");
            if (hijo != null)
                hijo.gameObject.SetActive(inventarioActivado);

            Debug.Log("Se activó el inventario");
        }
    }

    void ActivarAtributos()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            atributosActivado = !atributosActivado;
            Atributos.SetActive(atributosActivado);

            // Activar hijo explícitamente si existe
            Transform hijo = Atributos.transform.Find("atributos");
            if (hijo != null)
                hijo.gameObject.SetActive(atributosActivado);

            Debug.Log("Se activaron los atributos");
        }
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
}
