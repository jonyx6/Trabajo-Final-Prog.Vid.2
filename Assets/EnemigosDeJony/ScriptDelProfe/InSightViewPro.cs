using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InSightViewPro : MonoBehaviour
{
    [Header("Configuracion del cono")]
    public float radioDeVision = 5f;

    [Range(0, 360)] public float anguloDeVision = 90f;// le dice al inspecto que esto aparece con una barra deslizable.

    [Header("Colores del Gizmo")]
    public Color edgeColor = Color.green;
    public Color withoutDetect = Color.white;
    public Color withDetect = Color.red;

    [Header("Capas")]
    public LayerMask targetMask;    // Qu� puede ser detectado//nombre del objetivo
    public LayerMask obstacleMask;  // Qu� bloquea la visi�n// nombre del obstaculo si lo hay

    [Header("Debug")]
    public List<Transform> objetivosVisibles = new List<Transform>(); // lista de transform de los objetivos visibles

    private Transform objetivoActual;

    private readonly Collider2D[] _targetsBuffer = new Collider2D[20];// readonly:sirve para proteger la referencia de una variable despu�s de inicializarla

    private int _objetivoEncontrado;
    [SerializeField]
    private float distanciaDeAtaque;

    private void Update()
    {
        EncontrarObjetivosVisibles();
    }

    private void EncontrarObjetivosVisibles()
    {
        objetivosVisibles.Clear();

        _objetivoEncontrado = Physics2D.OverlapCircleNonAlloc(transform.position, radioDeVision, _targetsBuffer, targetMask);// devuelve la cantidad de objetos dentro del circulo creado.
        //OverlapCircleNonAlloc:no devuelve un array nuevo,
        //sino que rellena el array que vos le pas�s y te devuelve cu�ntos elementos se llenaron.

        for( int i = 0; i< _objetivoEncontrado; i++)
        {
            Collider2D colliderDelObjetivo = _targetsBuffer[i];
            if (colliderDelObjetivo == null) continue;
            {
                objetivoActual = colliderDelObjetivo.transform;

                if (EstaAlaVista())
                {
                    objetivosVisibles.Add(objetivoActual);
                }
            }
        }

    }

    public bool EstaAlaVista()
    {
        if (objetivoActual == null) return false;
        return EnRango() && EnAngulo() && EnVista();
    }

    public bool EnRango()
    {
        if (objetivoActual == null) return false;
        float distanacia = Vector2.Distance(transform.position, objetivoActual.transform.position);
        return distanacia <= radioDeVision;
    }

    private bool EnAngulo()
    {   
        Vector2 forward = transform.right;//fordward 2d
        Vector2 direccionHaciaElObjetivo =(objetivoActual.position - transform.position).normalized;
        float anguloAlObjetivo = Vector2.Angle(forward, direccionHaciaElObjetivo);

        return anguloAlObjetivo <= anguloDeVision;
    }

    private bool EnVista()
    {
        Vector2 origen = transform.position;
        Vector2  direccionHaciaElObjetivo = (objetivoActual.position - transform.position).normalized;
        float distancia = Vector2.Distance(origen,objetivoActual.position);
        return !Physics2D.Raycast(origen, direccionHaciaElObjetivo, distancia, obstacleMask);
    }

    public bool EstaCerca()
    {
        //Debug.Log("suestamente el Orco esta serca");
        if (objetivoActual == null) return false;

        float distancia = Vector2.Distance(transform.position, objetivoActual.position);

        return distancia < distanciaDeAtaque; // jony: harcodeado , puede mejorar con una variable attackRadius configurable desde el Inspector
        
    }



    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 forward = transform.right.normalized;

        // Bordes del cono
        Gizmos.color = edgeColor;
        Gizmos.DrawRay(origin, Quaternion.Euler(0, 0, anguloDeVision / 2f) * forward * radioDeVision);
        Gizmos.DrawRay(origin, Quaternion.Euler(0, 0, -anguloDeVision / 2f) * forward * radioDeVision);

        // Radio del cono
        if (objetivosVisibles.Count > 0)
        {
            Gizmos.color = withDetect; // rojo
        }
        else
        {
            Gizmos.color = withoutDetect; // blanco
        }


        Gizmos.DrawSphere(origin, radioDeVision);

        // Dibuja l�neas hacia los targets detectados
        foreach (Transform target in objetivosVisibles)
        {
            if (target == null) continue;

            if (target != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(origin, target.position);
            }


        }

    }
}
