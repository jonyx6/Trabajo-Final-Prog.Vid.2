using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class StaminaSystem : MonoBehaviour
{
    public float estamiaActual { get; private set ; }

    private Atributos aCharacter;

    private ControllerSystem csCharacter;

    public float cansancionProAtacque;

    public float cantDeRecuperacion;

    public event Action<float, float> OnStaminaChange;


    private bool estaCansado => estamiaActual < 2;

    

    private void Start()
    {
        aCharacter = GetComponent<Atributos>();
        estamiaActual = aCharacter.EstaminaMax;
        csCharacter = GetComponent<ControllerSystem>();

       
    }

    public void RestarUna_DeEstamina(float cantidad)
    {
        Debug.Log("esta restando");
         estamiaActual = Mathf.Max(0,estamiaActual-cantidad);
         OnStaminaChange?.Invoke(estamiaActual,aCharacter.EstaminaMax);
    }

    public void EstaAgotado()
    {
        if (estaCansado)
        {
            // detener personaje 

            csCharacter.enabled = false;
        }
        else
        {
            csCharacter.enabled = true;
        }
    }

    public void RecuperarEstamina(float cantidad)
    {
        estamiaActual = Mathf.Min(aCharacter.EstaminaMax , estamiaActual + cantidad);
        OnStaminaChange?.Invoke(estamiaActual, aCharacter.EstaminaMax);
    }





/*
    public void RecuperarEstamina()
    {
        IEnumerator corutine = RecuperarEstaminaPorSegundo();
        if (!csCharacter.EstaAtacando())
        {
            // iniciar corrutina que sume la estamina 

            StartCoroutine(corutine);
        }
        if(estamiaActual == aCharacter.EstaminaMax)
        {
            // pararia la corutina
            StopCoroutine(corutine);
        }
    }*/


    private void Update()
    {
        if (!csCharacter.EstaAtacando() ) 
        {
            RecuperarEstamina(cantDeRecuperacion*Time.deltaTime);

        }

        EstaAgotado();
    }
}
