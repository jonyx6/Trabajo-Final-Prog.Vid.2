using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(Atributos))]
public class SistemaDeSalud : MonoBehaviour
{
    [SerializeField]
    private string layerQueLeHaceDaño;
/*     [SerializeField]
    private float intervaloDeDanio = 0.5f; */

    public float CurrentHealth {  get; private set; }

    public bool IsDead => atributos.Vida < 1;

    [field:SerializeField]
    public float MaxHealth { get; set; }

    //aca declaro dos acciones que van a ocurrir 
    public event Action onDie;
    public event Action onTakeDamage;

    public Atributos atributos { get; private set; }

    void Start()
    {
        atributos = GetComponent<Atributos>();
    }

    public void Recibir_(float unDanio)
    {
        onTakeDamage?.Invoke();//se fija si tiene eventos subscrito y los ejecuta 
        atributos.Vida -= unDanio;
        if (IsDead)
        {
            onDie?.Invoke();
        }
    }
    public void Curarse_(float unaCuracion)
    {
        atributos.Vida += Math.Min(unaCuracion,atributos.VidaMaxima);
    }

/*     public IEnumerator Aplicar_(IDamager unDanio)
    {
        while(true)
        {
            Recibir_(unDanio.Damage());
            yield return new WaitForSeconds(intervaloDeDanio);
        }
    } */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(layerQueLeHaceDaño))
        {
            Debug.Log("daño hecho");
            IDamager danio = collision.gameObject.GetComponent<IDamager>();
            Recibir_(danio.Damage());
/*             IDamager danio = collision.gameObject.GetComponent<IDamager>();
            StartCoroutine(Aplicar_(danio)); */
        }
    }

/*     private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(layerQueLeHaceDaño))
        {
            StopAllCoroutines();
        }
    } */

    // dato: los ontrggerexit son espectaculares para parar acciones repetitivas de las corrutinas  

}
