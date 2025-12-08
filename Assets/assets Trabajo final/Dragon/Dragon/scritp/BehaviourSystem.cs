using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BehaviourSystem : MonoBehaviour
{
    public AnimationController animatonsDragon;

    public InSightViewPro1 inSightViewProDragon;

    public Transform vision;

    

    private Vector3 posicionVision;
    

    private SpriteRenderer spDragon;

    public GameObject _target;

   

    public Rigidbody2D rbDragon;

    private void Awake()
    {
        spDragon = GetComponent<SpriteRenderer>();
        rbDragon = GetComponent<Rigidbody2D>();
        posicionVision = vision.localPosition;


    }


    //para el ataque
    private Coroutine rutinaAtaque;

    [SerializeField] private Animator animatorDragon;


    private void Update()
    {

        if (_target != null)
        {
           Vector3 direccion = (_target.transform.position - transform.position).normalized;
            
            if (direccion.x < 0)
            {
                vision.transform.rotation = Quaternion.Euler(0f, 0f, -179f);
                vision.localPosition = new Vector3(-0.55f,posicionVision.y);

                spDragon.flipX = true;
            }
            if (direccion.x > 0)
            {
                vision.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                vision.localPosition = new Vector3(posicionVision.x, posicionVision.y);

                spDragon.flipX = false;
            }

        }
    }

    private void OnEnable()
    {
        animatonsDragon.OnPersuit += Acercarse;
        animatonsDragon.OnFlying += Volar;
        animatonsDragon.OnAwait += Esperar;
        animatonsDragon.OnAttacking += AtacarConFuego;

    }

    private void OnDisable()
    {
        animatonsDragon.OnPersuit -= Acercarse;
        animatonsDragon.OnFlying  -= Volar;
        animatonsDragon.OnAwait -= Esperar;
        animatonsDragon.OnAttacking -= AtacarConFuego;

    }


    public void Acercarse()
    {
        Debug.Log("el dragon camina");
        /*   transform.position = Vector3.MoveTowards
           (
               transform.position,
               _target.transform.position,
               1f * Time.deltaTime
           );*/
        rbDragon.velocity = ( _target.transform.position - transform.position ).normalized * 1f;


    }

    public void Volar()
    {
        Debug.Log("dragon vuela");
        
        
       Vector3 direction = (transform.position - _target.transform.position).normalized;

        //transform.position += direction * 5f * Time.deltaTime; // 5f esta harcodeado ..cambiarlo por una variable modificable en el inspector
        rbDragon.velocity = direction * 5f;
       

    }

    public void Esperar()
    {
        Debug.Log("el dragon espera");
        transform.position = transform.position;
        
    }




    public void AtacarConFuego()
    {
        Esperar();
        Debug.Log("el dragon se detiene para atacar ");
        animatorDragon.SetBool("Walk", false);
        


        if (rutinaAtaque == null)
                rutinaAtaque = StartCoroutine(AtacarRutina());
            
    }
      
    IEnumerator AtacarRutina()
    {
        Debug.Log("el dragon comenzo el ataque");
        while (inSightViewProDragon.EstaCerca())
        {

            animatorDragon.SetTrigger("Atack2");
            yield return new WaitForSeconds(3f); // espera 3 segundos
        }

        rutinaAtaque = null;
        
    }

    // comportamientos para la fase 2





}
