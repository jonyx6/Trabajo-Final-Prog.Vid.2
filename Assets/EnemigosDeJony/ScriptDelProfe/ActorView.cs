using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorView : MonoBehaviour
{
    private SistemaDeSalud _systemHealth;

    private Animation _anim;

    private void Awake()
    {
        _anim = GetComponent<Animation>();
        _systemHealth = GetComponent<SistemaDeSalud>();
    }
    private void OnEnable()
    {
        _systemHealth.onTakeDamage += TakeDamageView;
        _systemHealth.onDie += Die;
    }
    private void OnDisable()
    {
        _systemHealth.onTakeDamage -= TakeDamageView;
        _systemHealth.onDie -= Die;
    }

    public void TakeDamageView()
    {
        //Que ejecute una animacion
        _anim.Play();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

}