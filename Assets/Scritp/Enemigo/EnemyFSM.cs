using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EstadosEnemigo
{
    seeking,//siguiendo
    resting,//descansando
    attacking// atacando
}


[RequireComponent(typeof(InSightView))]
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyFSM : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float steeringPower;//que tan rapido o brusco cambia de direccion
    private EstadosEnemigo estado = EstadosEnemigo.resting;
    private InSightView _inSightView;
    private Rigidbody2D rb;
    private Transform target;
    // Start is called before the first frame update
    void Awake()
    {
        _inSightView = GetComponent<InSightView>();
        //lo dejo aca por que se usa en el onenable y este va antes del start
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case EstadosEnemigo.seeking:
                Seek(target);
                break;
            case EstadosEnemigo.resting:
                Rest();
                break;
            case EstadosEnemigo.attacking:
                Atacar();
                break;
            default:
                break;
        }
    }
    void OnDisable()
    {
        _inSightView.OnEnemyVisible -= AlVerAlEnemigo;
        _inSightView.OnEnemyNoVisible -= AlPerderAlEnemigo;
        _inSightView.OnProximityToTheEnemy -= AlAcercarce;
    }
    private void AlVerAlEnemigo(Transform enemigo)
    {
       
        estado = EstadosEnemigo.seeking;
        target = enemigo;

    }
    private void AlPerderAlEnemigo()
    {
        estado = EstadosEnemigo.resting;
        target = null;
    }

    public void AlAcercarce(Transform enemigo)////
    {

        estado = EstadosEnemigo.attacking;
        target = enemigo;

       
    }

    void Seek(Transform target)
    {
        _inSightView.OnEnemyNoVisible += AlPerderAlEnemigo;
        // Calcular dirección deseada hacia el objetivo
        Vector2 desiredVelocity = (target.position - transform.position).normalized * maxSpeed;

        // Calcular fuerza de steering (diferencia entre deseado y actual)
        Vector2 steering = desiredVelocity - rb.velocity;

        // Aplicar steering a la velocidad actual
        rb.velocity += steeringPower * Time.deltaTime * steering;

        RotarSegunVelocidad(desiredVelocity);
    }
    void Rest()
    {
        _inSightView.OnEnemyVisible += AlVerAlEnemigo;
    }

    void Atacar()
    {
        // corregir 
        _inSightView.OnProximityToTheEnemy += AlAcercarce;
        Debug.Log(" el Enemigo esta atacanfo");

        // deberi aplicar la logica de ataque?
    }

   

    void RotarSegunVelocidad(Vector2 velocidad)
    {
        Vector3 eulerAngle = transform.rotation.eulerAngles;
        eulerAngle.y = velocidad.x > 0 ? 0f : -180f;
        transform.rotation = Quaternion.Euler(eulerAngle);
    }


}
