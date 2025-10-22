using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class Fsm : MonoBehaviour
{
    private Animator animPersonaje;
    private Rigidbody2D rbPersonaje; 
    private Camera cam;
    private Atributos aPersonaje;
    private SpriteRenderer spPersonaje;
    private Vector2 target;
    private float angulo;
    public float  Angulo => angulo;// solo lectura.
    

    private void Awake()
    {
        animPersonaje = GetComponent<Animator>();
        rbPersonaje = GetComponent<Rigidbody2D>();
        aPersonaje = GetComponent<Atributos>();
        spPersonaje = GetComponent<SpriteRenderer>();
        cam = Camera.main;
        
    }

    void OrientarPersonajeHacia_(float unAngulo)
    {
         if(MirandoIzquierda(unAngulo))
         {            
             spPersonaje.flipX = false;
         }else{

            spPersonaje.flipX = true;
         }

    }

    public bool MirandoIzquierda(float angulo)
    {
        return angulo > -110f && angulo <= 90f;
    }



    void EstaCaminando(Vector2 unaDireccion)
    {
        if(unaDireccion.x!= 0 || unaDireccion.y != 0)
        {
            
            Cambiar_A_("isWalk", true);
        }
        else
        {
            
            Cambiar_A_("isWalk", false);
        }

    }

    void EstaMuerto() {
        if(aPersonaje.Vida < 1)
        {
            Cambiar_A_("isDeath", true);
        }
    }

    void EstaAtacando()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Cambiar_A_("isAttacking1",true);
            aPersonaje.Velocidad = 0;
        }
    }


    void Cambiar_A_(string unaAnimacion,bool unValorDeVerdad)
    {
        // prop: sirve para activar o desactivar cualquier animacion de la maquina de estado
        animPersonaje.SetBool(unaAnimacion, unValorDeVerdad);
    }


    

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = cam.ScreenToWorldPoint(Input.mousePosition);//comvierte las cordenadad del screen en las del wordspace
        }
        Vector2 direccion = (target - (Vector2)transform.position).normalized;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        AnimatorStateInfo estado = animPersonaje.GetCurrentAnimatorStateInfo(0);

        if (estado.IsName("attack1") && estado.normalizedTime >= 1f)
        {
            Cambiar_A_("isAttacking1", false);
            aPersonaje.Velocidad = 1;
        }else if (Input.GetKeyDown(KeyCode.R) && estado.IsName("attack1") && estado.normalizedTime < 1f)
        {
            Cambiar_A_("isAttacking1", false);
            Cambiar_A_("isAttacking2", true);
            //aPersonaje.Velocidad = 0;
        }
        if (estado.IsName("attack2") && estado.normalizedTime >= 1f)
        {
            Cambiar_A_("isAttacking1", false);
            Cambiar_A_("isAttacking2", false);
            aPersonaje.Velocidad = 1;
        }

        OrientarPersonajeHacia_(angulo);
        EstaCaminando(direccion);
        EstaMuerto();
        EstaAtacando();

        
    }




}
