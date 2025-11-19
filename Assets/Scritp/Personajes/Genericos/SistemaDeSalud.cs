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
    
    private Atributos _atributos;

    void Start()
    {
        _atributos = GetComponent<Atributos>();
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
            MorirPor(atacante);
        }
    }
    private void RecibirUnDaño(float cantDaño)
    {
        float dañoRecibido = Mathf.Max(0,cantDaño - _atributos.Pd);
        _atributos.CambiarVida(_atributos.Vida - dañoRecibido);
        OnTakeDamage?.Invoke();
    }

    private void MorirPor(IDamager FunteDeDaño)
    {
        FunteDeDaño.DarXP(_atributos.ExpAEntregar);
        OnDie?.Invoke();
        StartCoroutine(Desaparecer());
    }
    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
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
}
