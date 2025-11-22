using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
//esta clase se encarga de la logica relacionada con los proyectiles
//el movimiento de estos
//el daño que estos hacen
//lo que sucede si logran matar al enemigo en este caso dar xp
//detecta cuando deben destruirse(al impactar muro o enemigo) o al pasar el tiempo de vida

//el proyectil no sabe ni debe saber quien lo lanza
public class Proyectile : MonoBehaviour, IDamager
{
    public float speed = 25f;
    public float lifeTime = 5f;
    [SerializeField]
    private float damage;
    public event Action<float> AlRecibirXp;
    private Rigidbody2D rb;
    [SerializeField]
    private string layerDeObstaculo = "Obstaculo";
    [SerializeField]
    private string layerDeEnemigo = "Enemigo";

    //metodos de unity
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        //esto hace que pasado un tiempo se destruya la flecha
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (PerteneceAlLayer(collision, layerDeObstaculo) || PerteneceAlLayer(collision, layerDeEnemigo))
        {
            Destroy(gameObject);
        }
    }
    void OnDisable()
    {
        StartCoroutine(DesuscribirEventoDeDarXpEn1Segundo());
    }

    //metodos de Idamager
    //el daño que hace
    public float Damage()
    {
        return damage;
    }

    //sirve para casos como un personaje que dispara y al matar recibe xp
    public void DarXP(float expAEntregar)
    {
        Debug.Log("flecha recibio xp");
        AlRecibirXp?.Invoke(expAEntregar);
    }

    //metodos y boleanos auxiliares

    private bool PerteneceAlLayer(Collider2D collider2D, string layer)
    {
        return collider2D.gameObject.layer == LayerMask.NameToLayer(layer);
    }
    //aumenta el daño del proyectil sirve para casos como un lanzador que agrega daño extra
    public void AumentarDaño(float cantidad)
    {
        damage += cantidad;
    }

    private IEnumerator DesuscribirEventoDeDarXpEn1Segundo()
    {
        yield return new WaitForSeconds(1);
        AlRecibirXp = null;
    }
}