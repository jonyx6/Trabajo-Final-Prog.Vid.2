using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ControllerSystem : MonoBehaviour
{
    private Atributos aPersonaje;
    private Rigidbody2D _rigidbody2D;
    private Camera cam;
    private Vector2 target;// guarda la posicion donde hago el clik
    private Vector2 direccion;

 
    private void Awake()
    {
        cam = Camera.main;
        target = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        aPersonaje = GetComponent<Atributos>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = cam.ScreenToWorldPoint(Input.mousePosition);//comvierte las cordenadad del screen en las del wordspace
        }

        if (Vector2.Distance(target, (Vector2)transform.position) > 0.2f)
        {
            direccion = (target - (Vector2)transform.position).normalized;
        }
        else
        {
            direccion = Vector2.zero;
        }
        
    }
    void FixedUpdate()
    {
        _rigidbody2D.velocity = direccion * aPersonaje.Velocidad;
    }


}
