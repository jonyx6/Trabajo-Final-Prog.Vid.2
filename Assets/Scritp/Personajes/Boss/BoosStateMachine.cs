using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BoosStateMachine : MonoBehaviour
{
    //public List<IEnumerator> ataques = new();
    public Transform character;
    private Rigidbody2D rb;
    private Collider2D col2D;
    private Animator animator;
    private float velocidad = 3f; // ajusta según necesites

    private const float DISTMINIMA = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col2D = GetComponent<Collider2D>();

        StartCoroutine(EmpezarBatalla());
    }
    // private IEnumerator patronDeAtaque()
    // {
    //     while (true)
    //     {
    //         //elegir ataque aleatorio
    //         IEnumerator ataqueAleatorio = ataques[Random.Range(0, ataques.Count)];
    //         //esperar que termine el ataque
    //         yield return StartCoroutine(ataqueAleatorio);
    //         //descansa
    //         Debug.Log("descansando");
    //         yield return new WaitForSeconds(1);
    //         //vuelve a empezar
    //     }
    // }
    private IEnumerator EmpezarBatalla()
    {
        animator.SetBool("Flight", true);
        yield return StartCoroutine(PerseguirA(character,10));
        animator.SetBool("Flight", false);

        StartCoroutine(Ataque1());
    }
    private IEnumerator Ataque1()
    {
        AnimatorStateInfo estado = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitUntil(() => Vector2.Distance(character.position, transform.position) < 5f);

        animator.SetTrigger("Atack2");
        yield return new WaitForSeconds(1);
        StartCoroutine(Ataque2());
    }
    private IEnumerator Ataque2()
    {
        Debug.Log("comienzo ataque 2");
        animator.SetBool("Flight", true);
        yield return StartCoroutine(IrHacia((Vector2)character.position - new Vector2(-10,-10)));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(PerseguirA2(character));
        Debug.Log("final ataque 2");
    }
    private IEnumerator PerseguirA(Transform objetivo,float distPerseucion)
    {
        while (Vector2.Distance(objetivo.position, transform.position) > distPerseucion)
        {
            Vector2 direccion = (objetivo.position - transform.position).normalized;
            rb.AddForce(direccion * velocidad);
            yield return new WaitForFixedUpdate();
        }
        rb.velocity = Vector2.zero;
    }
    private IEnumerator PerseguirA2(Transform objetivo)
    {
        while (Vector2.Distance(objetivo.position, transform.position) > 5)
        {
            Vector2 direccion = (objetivo.position - transform.position).normalized;
            rb.AddForce(direccion * velocidad);
            yield return new WaitForFixedUpdate();
        }
        animator.SetTrigger("EspecialAtack");
        yield return StartCoroutine(IrHacia((Vector2)transform.position + new Vector2(-10, -10)));        
        rb.velocity = Vector2.zero;
    }
    private IEnumerator IrHacia(Vector2 position)
    {
        while (Vector2.Distance(position, transform.position) > DISTMINIMA)
        {
            Vector2 direccion = (position - (Vector2)transform.position).normalized;
            rb.AddForce(direccion * velocidad);
            yield return new WaitForFixedUpdate();
        }
        rb.velocity = Vector2.zero;
    }
    //ataque 1: el dragon espera que el jugador se acerque y escupe fuego
    //ataque 2: el dragon camina hacia el jugador y escupe fuego
    //ataque 3: el dragon vuela y tira fuego 2 veces en x
    //ataque 4: el dragon hace un circulo de fuego
}
