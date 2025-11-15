using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class SistemaDeSalud : MonoBehaviour
{
    [SerializeField]
    private float intervaloDeDanio = 0.5f;

    public float CurrentHealth {  get; private set; }

    public bool isDead => CurrentHealth < 1;

    [field:SerializeField]
    public float MaxHealth { get; set; }

    //aca declaro dos acciones que van a ocurrir 
    public event Action onDie;
    public event Action onTakeDamage;

    public void SetHealth(float MaxHeald)
    {
        // funcion que setea la vida maxima a la vida actual del personaje
        CurrentHealth = MaxHealth;
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Recibir_(float unDanio)
    {
        onTakeDamage?.Invoke();//se fija si tiene eventos subscrito y los ejecuta 
        CurrentHealth -= unDanio;
        if (isDead)
        {
            onDie?.Invoke();
        }
    }

    public IEnumerator Aplicar_(IDamager unDanio)
    {
        while(true)
        {
            Recibir_(unDanio.Damage);
            yield return new WaitForSeconds(intervaloDeDanio);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Damage"))
        {
            Debug.Log("daño hecho");
            IDamager danio = collision.gameObject.GetComponent<IDamager>();
            StartCoroutine(Aplicar_(danio));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Damage"))
        {
            StopAllCoroutines();

        }
    }

    // dato: los ontrggerexit son espectaculares para parar acciones repetitivas de las corrutinas  

}
