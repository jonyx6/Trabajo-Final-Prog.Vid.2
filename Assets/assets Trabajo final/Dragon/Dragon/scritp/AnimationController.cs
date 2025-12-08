using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AnimationController : MonoBehaviour
{
    //clase hecha para controlar las animaciones usando el in sight view;
    [SerializeField] private InSightViewPro1 inSightViewProDragon;
    [SerializeField] private Animator animatorDragon;

    [SerializeField] private Atributos atributosDragon;

    // eventos preparados para una clase que se encargue de los comportaminetos
    public Action OnAwait;
    public Action OnPersuit;
    public Action OnFlying;
    public Action OnAttacking;


    public bool estaVolando = false;


    


    //private Coroutine rutinaAtaque;



    private void Awake()
    {
        atributosDragon.Vida = atributosDragon.VidaMaxima;
        OnAwait?.Invoke();
    }

    private void Update()
    {
        if(inSightViewProDragon.objetivoActual != null && atributosDragon.Vida > atributosDragon.VidaMaxima *0.7f)
        {
            Debug.Log("pasa al patron 1 de ataque");
            PatronDeAtaqueA();
        }
        if(inSightViewProDragon.objetivoActual != null && atributosDragon.Vida <= atributosDragon.VidaMaxima * 0.7f)
        {
            Debug.Log("pasa al patron 2 de ataque");
        }

    }

    public void PatronDeAtaqueA()
    {
        PerseguirSiEstaALaVista();
        EscaparVolandoSiNoEstaEnAngulo();
        AterrizarSiEsSeguro();
        AtacarSiEstaEnSerca();

    }




    public void PerseguirSiEstaALaVista()
    {
        bool persiguiendo = inSightViewProDragon.EstaAlaVista();
        animatorDragon.SetBool("Walk", persiguiendo);

        if (persiguiendo && !inSightViewProDragon.EstaCerca() && !estaVolando)
        {
            OnPersuit?.Invoke();
        }
           
        if( !persiguiendo)
        {
            estaVolando = false;
            OnAwait?.Invoke();

        }
           

    }

    public void EscaparVolandoSiNoEstaEnAngulo()
    {
        if (!inSightViewProDragon.EnAngulo() && inSightViewProDragon.EnRango())
        {
            inSightViewProDragon.GetComponent<InSightViewPro1>().anguloDeVision = 0f;
            inSightViewProDragon.GetComponent<InSightViewPro1>().radioDeVision = 6f;
            estaVolando = true;
            animatorDragon.SetBool("Flight", true);
            OnFlying?.Invoke();
        }
    }

    public void AterrizarSiEsSeguro()
    {
        if (!inSightViewProDragon.EnRango() )
        {
            inSightViewProDragon.GetComponent<InSightViewPro1>().anguloDeVision = 160f;
            inSightViewProDragon.GetComponent<InSightViewPro1>().radioDeVision = 10f;

            estaVolando = false;
            animatorDragon.SetBool("Flight", false);
            OnAwait?.Invoke();

        }
    }

    public void AtacarSiEstaEnSerca()
    {
        if (inSightViewProDragon.EstaCerca())
        {
            OnAttacking?.Invoke();
        }
    }




}
