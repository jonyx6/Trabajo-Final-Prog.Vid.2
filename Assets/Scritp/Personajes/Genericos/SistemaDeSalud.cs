using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Atributos))]
public class SistemaDeSalud : MonoBehaviour
{

    
    /* el sistema de salud se encarga de que al recibir daño pierdas vida o mueras */
    [SerializeField]
    private string layerQueHaceDaño;

    private bool IsDead => _atributos.Vida < 1;

    //aca declaro las acciones que van a ocurrir 
    public event Action OnDie;
    public event Action OnTakeDamage;

    public event Action<float, float> OnVidaChange;

    private Atributos _atributos;

    

    void Start()
    {
        _atributos = GetComponent<Atributos>();
        _atributos.Vida = _atributos.VidaMaxima;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objetoColisionado = collision.gameObject;
        bool puedeRecibirDaño = PuedeRecibirDañoDe_(objetoColisionado);
        if (puedeRecibirDaño && !IsDead)
        {
            IDamager atacante = objetoColisionado.GetComponent<IDamager>();
            RecibirDañoDe_(atacante);
        }
    }

    private void RecibirDañoDe_(IDamager atacante)
    {
        RecibirUnDaño(atacante.Damage());

        if (IsDead)
        {
            EjecutarMuertePor(atacante);
        }
    }
    private void RecibirUnDaño(float cantDaño)
    {
        float dañoRecibido = Mathf.Max(0,cantDaño - _atributos.Pd);
        CambiarVida(_atributos.Vida - dañoRecibido);
        OnTakeDamage?.Invoke();
    }
    

    private void EjecutarMuertePor(IDamager FunteDeDaño)
    {
        FunteDeDaño.DarXP(_atributos.ExpAEntregar);// da exp
        OnDie?.Invoke();// invoca eventos de muerte
        StartCoroutine(Morir());// ejecuta morir
    }


    IEnumerator Morir()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    public void Curarse(float cantCuracion)
    {
        float curacionRecibida = Mathf.Min(_atributos.VidaMaxima,_atributos.Vida +cantCuracion);
        CambiarVida(_atributos.Vida - curacionRecibida);
    }

    private bool PuedeRecibirDañoDe_(GameObject unaFuenteDeDaño)
    {
        return PerteneceAlLayer_(unaFuenteDeDaño,layerQueHaceDaño) && EsUnaFuenteDeDaño(unaFuenteDeDaño);
    }

    private bool PerteneceAlLayer_(GameObject unGameObject,string unLayer)
    {
        return unGameObject.layer == LayerMask.NameToLayer(unLayer);
    }

    private bool EsUnaFuenteDeDaño(GameObject unObjeto)//armas o proyectiles
    {
        return unObjeto.GetComponent<IDamager>() != null;
    }


    ////----////
    public void CambiarVida(float nuevaVida)
    {
       _atributos.Vida  = nuevaVida;
        OnVidaChange?.Invoke(_atributos.Vida,_atributos.VidaMaxima);
    }

    public void CambiarVidaMaxima(float nuevaVida)
    {
        _atributos.VidaMaxima = nuevaVida;
        OnVidaChange?.Invoke(_atributos.Vida, _atributos.VidaMaxima);
    }
}
