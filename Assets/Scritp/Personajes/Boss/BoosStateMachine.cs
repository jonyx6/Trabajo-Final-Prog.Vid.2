using System.Collections;
using UnityEngine;

public enum BoosBaseStates
{
    idle,
    patronAtaque1,
    patronAtaque2,
    patronAtaque3
}
public class BoosStateMachine : MonoBehaviour
{
    public BoosBaseStates estadoBase;
    //public List<IEnumerator> ataques = new();
    public Transform target;
    public Transform origen;
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

        StartCoroutine(CicloDeMovimiento());
    }
    void Update()
    {
        if (transform.position.x < target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        switch (estadoBase)
        {
            case BoosBaseStates.patronAtaque1:
                Patron1();
                break;
            case BoosBaseStates.patronAtaque2:
                Patron2();
                break;
            case BoosBaseStates.patronAtaque3:
                Patron3();
                break;
            default:
                break;
        }
    }
    private void AsignarRotacion()
    {
        
    }
    //perseguir y atacar
    private void Patron1()
    {
        Debug.Log("Patron1");
        if (Vector3.Distance(target.position, origen.position) < 1)
        {
            animator.SetBool("Walk", false);
            animator.SetTrigger("Atack2");
        }
        else
        {
            Perseguir();
        }
    }
    private void Patron2()
    {
        Debug.Log("Patron2");
        if (Vector3.Distance(target.position, origen.position) < 10)
        {
            Huir();
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetTrigger("Atack1");
        }
    }
    private void Patron3()
    {
        Debug.Log("Patron3");
        if (Vector3.Distance(target.position, origen.position) < 6)
        {
            animator.SetBool("Walk", false);
            animator.SetTrigger("Atack1");
        }
        else
        {
            Perseguir();
        }
    }

    private void Huir()
    {
        animator.SetBool("Walk", true);
        Vector3 direction = (transform.position - origen.position).normalized;
        transform.position += Time.deltaTime * velocidad * direction;
    }
    private void Perseguir()
    {
        animator.SetBool("Walk", true);
        Vector3 direction = (target.position - origen.position).normalized;
        transform.position += Time.deltaTime * velocidad * direction;
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
    private IEnumerator CicloDeMovimiento()
    {
        //ejecuta y espera que termine la coroutine entrada
        yield return Entrada();
        while (true)
        {
            animator.SetBool("Walk", false);
            estadoBase = BoosBaseStates.idle;
            yield return new WaitForSeconds(4);
            estadoBase = PatronDeAtaqueAleatorio();
            yield return new WaitForSeconds(10);
        }

        //StartCoroutine(Idle());
        //StartCoroutine(Idle());
        /*         animator.SetBool("Flight", true);
                //acercarse y aterrizar
                yield return StartCoroutine(Entrada());
                animator.SetBool("Flight", false);

                //entra a idle
                StartCoroutine(Idle()); */
    }
    private BoosBaseStates PatronDeAtaqueAleatorio()
    {
        BoosBaseStates[] patrones = { BoosBaseStates.patronAtaque1/* , BoosBaseStates.patronAtaque2, BoosBaseStates.patronAtaque3 */ };
        return patrones[Random.Range(0, patrones.Length)];
    }
    private IEnumerator Entrada()
    {
        yield return PerseguirA(target, 10);
    }
    private IEnumerator Idle()
    {
        Debug.Log("entro en idle");
        yield return new WaitForSeconds(3);
        Debug.Log("Termino idle");
    }
    private IEnumerator Ataque()
    {
        Debug.Log("entro en ataque");
        yield return new WaitForSeconds(3);
        Debug.Log("Termino ataque");
    }

    private IEnumerator Ataque1()
    {
        AnimatorStateInfo estado = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitUntil(() => Vector2.Distance(target.position, transform.position) < 5f);

        animator.SetTrigger("Atack2");
        yield return new WaitForSeconds(1);

        //ataque complejo
        StartCoroutine(Ataque2());
    }
    private IEnumerator Ataque2()
    {
        Debug.Log("comienzo ataque 2");
        animator.SetBool("Flight", true);
        //aca va a la diagonal superior de jugador
        yield return StartCoroutine(IrHacia((Vector2)target.position - new Vector2(-10, -10)));
        yield return new WaitForSeconds(1);
        //aca se mueve hacia el jugador
        yield return StartCoroutine(PerseguirA2(target));
        yield return new WaitForSeconds(4);

        /*         yield return StartCoroutine(IrHacia((Vector2)character.position - new Vector2(10,-10)));
                yield return new WaitForSeconds(1);
                //aca se mueve hacia el jugador
                yield return StartCoroutine(PerseguirA2(character)); */
        Debug.Log("final ataque 2");
    }
    private IEnumerator PerseguirA(Transform objetivo, float distPerseucion)
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origen.position,1);
    }
}
