using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Sistema de ataque")]
    private AttackSystem asEnemy;

    [Header("Atributos")]
    private Atributos aEnemy;

    [Header("Sistema de getsion De Vida")]

    private HealdSystem hsEnemy;

    void Awake()
    {
        asEnemy = GetComponent<AttackSystem>();
        aEnemy = GetComponent<Atributos>();
        hsEnemy = GetComponent<HealdSystem>();
    }

    private void Update()
    {
        Debug.Log("la Vida actual de " + aEnemy.Nombre + " es " + aEnemy.Vida);
        hsEnemy.Morir();
    }

    
}
