using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorView : MonoBehaviour
{
    private SistemaDeSalud _systemHealth;

    private Animator _anim;
    public MonoBehaviour scriptADesactivar;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
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
        _anim.SetTrigger("isHurt");
    }

    public void Die()
    {
        _anim.SetBool("isDeath",true);
        scriptADesactivar.enabled = false;
    }

}