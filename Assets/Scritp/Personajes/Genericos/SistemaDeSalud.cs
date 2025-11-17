using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Atributos))]
public class SistemaDeSalud : MonoBehaviour
{
    [SerializeField]
    private string layerQueLeHaceDaño;
    /*     [SerializeField]
        private float intervaloDeDanio = 0.5f; */

    public bool IsDead => _atributos.Vida < 1;

    //aca declaro dos acciones que van a ocurrir 
    public event Action onDie;
    public event Action onTakeDamage;
    public event Action onTakeHeal;
    public event Action<float, float> OnChange;

    public Atributos _atributos;

    void Start()
    {
        _atributos = GetComponent<Atributos>();
        OnChange?.Invoke(_atributos.Vida, _atributos.VidaMaxima);
    }

    public void RecibirDañoDe_(IDamager FunteDeDaño)
    {
        _atributos.CambiarVida(_atributos.Vida - Math.Max(0,FunteDeDaño.Damage() - _atributos.Pd));
        onTakeDamage?.Invoke();
        if (IsDead)
        {
            MorirPor(FunteDeDaño);
        }
    }
    public void Curarse_(float unaCuracion)
    {
        _atributos.CambiarVida(Math.Min(_atributos.Vida + unaCuracion, _atributos.VidaMaxima));
        onTakeHeal?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(layerQueLeHaceDaño) && !IsDead)
        {
            Debug.Log("daño hecho");
            IDamager danio = collision.gameObject.GetComponent<IDamager>();
            RecibirDañoDe_(danio);
        }
    }
    private void MorirPor(IDamager FunteDeDaño)
    {
        FunteDeDaño.DarXP(_atributos.ExpAEntregar);
        onDie?.Invoke();
        StartCoroutine(Desaparecer());
    }
    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
