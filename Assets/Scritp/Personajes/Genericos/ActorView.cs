using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        _systemHealth.OnTakeDamage += TakeDamageView;
        _systemHealth.OnDie += Die;
    }
    private void OnDisable()
    {
        _systemHealth.OnTakeDamage -= TakeDamageView;
        _systemHealth.OnDie -= Die;
    }

    public void TakeDamageView()
    {
        //Que ejecute una animacion
        Debug.Log("take dame");
        _anim.SetTrigger("isHurt");
    }

    public void Die()
    {
        _anim.SetTrigger("isDeath");
        scriptADesactivar.enabled = false;
        

    }

}