using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ControllerSystem : MonoBehaviour
{
    private Atributos aPersonajes;
    private Camera cam;
    private Vector2 target;// guarda la posicion donde hago el clik
    private void Awake()
    {
        cam = Camera.main;
        aPersonajes = GetComponent<Atributos>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = cam.ScreenToWorldPoint(Input.mousePosition);//comvierte las cordenadad del screen en las del wordspace
        }
        Vector2 direccion = (target - (Vector2)transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position,target,aPersonajes.Velocidad * Time.deltaTime);

        Debug.Log(direccion);
    }


}
