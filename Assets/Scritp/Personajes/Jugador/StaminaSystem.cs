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

    [SerializeField]
    private float cantDeRecuperacion;

    public event Action<float, float> OnStaminaChange;

    


    public bool estaCansado => estamiaActual < cansancionProAtacque; 

    private Animator animCharacter;

    

    private void Start()
    {
        aCharacter = GetComponent<Atributos>();
        estamiaActual = aCharacter.EstaminaMax;
        csCharacter = GetComponent<ControllerSystem>();
        animCharacter = GetComponent<Animator>();

        cantDeRecuperacion = aCharacter.cantDeRecuperacion;


        cansancionProAtacque = aCharacter.Pa;


    }

    public void RestarUna_DeEstamina(float cantidad)
    {
        Debug.Log("esta restando");
         estamiaActual = Mathf.Max(0,estamiaActual-cantidad);
         OnStaminaChange?.Invoke(estamiaActual,aCharacter.EstaminaMax);
    }



    public void RecuperarEstamina(float cantidad)
    {
        estamiaActual = Mathf.Min(aCharacter.EstaminaMax , estamiaActual + cantidad);
        OnStaminaChange?.Invoke(estamiaActual, aCharacter.EstaminaMax);
    }




    private void Update()
    {
        if (!csCharacter.EstaAtacando() ) 
        {
            RecuperarEstamina(cantDeRecuperacion*Time.deltaTime);

        }

        

       
    }
}
