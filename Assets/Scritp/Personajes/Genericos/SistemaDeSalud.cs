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

    public bool IsDead => CurrentHealth < 1;

    [field:SerializeField]
    public float MaxHealth { get; set; }

    //aca declaro dos acciones que van a ocurrir 
    public event Action onDie;
    public event Action onTakeDamage;
    public event Action onTakeHeal;
    public event Action<float,float> onHealthChange;

    public Atributos atributos { get; private set; }

    void Start()
    {
        atributos = GetComponent<Atributos>();
        MaxHealth = atributos.Vida;
        CurrentHealth = MaxHealth;
        onHealthChange?.Invoke(CurrentHealth,MaxHealth);
    }

    public void Recibir_(float unDanio)
    {
        CurrentHealth -= unDanio;
        onHealthChange?.Invoke(CurrentHealth,MaxHealth);
        onTakeDamage?.Invoke();//se fija si tiene eventos subscrito y los ejecuta 
        if (IsDead)
        {
            onDie?.Invoke();
        }
    }
    public void Curarse_(float unaCuracion)
    {
        CurrentHealth += Math.Min(unaCuracion,atributos.VidaMaxima);
        onHealthChange?.Invoke(CurrentHealth,MaxHealth);
        onTakeHeal?.Invoke();
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
    void Update()
    {
        Debug.Log(CurrentHealth);
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
