using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonDeObjeto : MonoBehaviour
{
    [SerializeField]
    private Image imagenAsignada;
    public bool sePuedeUsar{get;private set;} = true;

    internal void Usar(float recuperacionDeAtaque)
    {
        StartCoroutine(RecargarBoton(imagenAsignada,recuperacionDeAtaque));
    }

    IEnumerator RecargarBoton(Image unBoton, float duracion)
    {
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            unBoton.fillAmount = tiempo / duracion;
            sePuedeUsar = false;
            yield return null;
        }
        sePuedeUsar = true;
        unBoton.fillAmount = 1f;
    }
}
