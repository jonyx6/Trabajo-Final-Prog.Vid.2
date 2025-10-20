using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class Fsm : MonoBehaviour
{
    private Animator animPlayer;
    private Rigidbody2D rbPlayer; 
    private Camera cam;
    private Atributos aPersonaje;
    private Vector2 target;

    private void Awake()
    {
        animPlayer = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
        aPersonaje = GetComponent<Atributos>();
        cam = Camera.main;
    }

 

    void OrientarPersonajeHacia_(float unAngulo)
    {
         if(unAngulo >= -45f && unAngulo < 45f)
         {            
             animPlayer.SetBool("miraDerecha", true);
             animPlayer.SetBool("miraArriba", false);
             
             animPlayer.SetBool("miraIzquierda", false);
         }
         if (unAngulo >= 45f && unAngulo < 135f)
         {
             animPlayer.SetBool("miraArriba", true);
             
             animPlayer.SetBool("miraIzquierda", false);
             animPlayer.SetBool("miraDerecha", false);
         }
         if (unAngulo >= 135f || unAngulo < -135f)
         {
             
             animPlayer.SetBool("miraIzquierda", true);
             animPlayer.SetBool("miraDerecha", false);
             animPlayer.SetBool("miraArriba", false);
         }
         if (unAngulo >= -135f && unAngulo < -45f || unAngulo ==0)
         {
             animPlayer.SetBool("miraIzquierda", false);
             animPlayer.SetBool("miraDerecha", false);
             animPlayer.SetBool("miraArriba", false);
             
         }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = cam.ScreenToWorldPoint(Input.mousePosition);//comvierte las cordenadad del screen en las del wordspace
        }
        Vector2 direccion = (target - (Vector2)transform.position).normalized;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        OrientarPersonajeHacia_(angulo);
        Debug.Log("el angulo es : " + angulo);

    }




}
