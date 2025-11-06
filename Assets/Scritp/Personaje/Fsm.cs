using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Fsm : MonoBehaviour
{
    private Animator animPersonaje;
    private Rigidbody2D rbPersonaje;
    private Camera cam;
    private Personaje Personaje;
    private SpriteRenderer spPersonaje;
    private float angulo;
    public float Angulo => angulo;// solo lectura.
    private float velocidadActualDelPersonaje;
    public Image boton1;

    public Image boton3;



    private void Awake()
    {
        animPersonaje = GetComponent<Animator>();
        rbPersonaje = GetComponent<Rigidbody2D>();
        Personaje = GetComponent<Personaje>();
        spPersonaje = GetComponent<SpriteRenderer>();
        cam = Camera.main;





    }

    void OrientarPersonajeHacia_(float unAngulo)
    {
        if (MirandoIzquierda(unAngulo))
        {
            spPersonaje.flipX = false;
        }
        else
        {

            spPersonaje.flipX = true;
        }

    }
    void OrientarPersonaje()
    {
        Vector2 target = cam.ScreenToWorldPoint(Input.mousePosition);//comvierte las cordenadad del screen en las del wordspace
        //conseguimos 
        if (target.x > transform.position.x)
        {
            spPersonaje.flipX = false;
        }
        else
        {
            spPersonaje.flipX = true;
        }

    }

    public bool MirandoIzquierda(float angulo)
    {
        return angulo > -110f && angulo <= 90f;
    }



    void EstaCaminando()
    {
        //sqrMagnitude convierte la velocidad en un numero
        //si la velocidad es menor a 0.1 no se muestra la animacionDeCaminando
        Cambiar_A_("isWalk", rbPersonaje.velocity.sqrMagnitude >= 0.1);
    }

    void EstaMuerto()
    {
        if (Personaje.atributos.Vida < 1)
        {
            Cambiar_A_("isDeath", true);
        }
    }

    void EstaAtacando()
    {
        AnimatorStateInfo estado = animPersonaje.GetCurrentAnimatorStateInfo(0);
        if (estado.IsName("attack1") || estado.IsName("attack2") || estado.IsName("especialAtack"))
        {
            rbPersonaje.velocity = Vector2.zero;
        }
    }
    void AtaqueSimple()
    {
        if (Input.GetKeyDown(KeyCode.R) && boton3.fillAmount == 1)
        {
            Debug.Log("sr atacao simple");
            animPersonaje.SetTrigger("isAtacking");
        }
    }

    void AtaqueEspecial()
    {
        if (Input.GetKeyDown(KeyCode.W) && boton1.fillAmount == 1)
        {
            animPersonaje.SetTrigger("isEspecialAtacking");
        }
    }


    void Cambiar_A_(string unaAnimacion, bool unValorDeVerdad)
    {
        // prop: sirve para activar o desactivar cualquier animacion de la maquina de estado
        animPersonaje.SetBool(unaAnimacion, unValorDeVerdad);
    }




    public void Update()
    {
        AtaqueSimple();
        AtaqueEspecial();
        OrientarPersonaje();
        EstaCaminando();
        EstaAtacando();
        EstaMuerto();
    }






}
