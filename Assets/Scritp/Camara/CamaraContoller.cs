using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraContoller : MonoBehaviour
{
    public Transform objetivo;
    public float velocidadCamara = 0.025f;
    public Vector3 desplazamiento;
    [SerializeField]
    private Vector2 tamañoDeZonaVisual;
    [SerializeField]
    private Vector2 posDeZonaVisual;

    private void LateUpdate()
    {
        Vector3 posicionDeseada = objetivo.position + desplazamiento;

        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velocidadCamara);

        
    }
    private void Update()
    {
        Vector3 posicionDeseada = objetivo.position ;

        posicionDeseada = Vector3.Lerp(transform.position, posicionDeseada, velocidadCamara * Time.deltaTime);

        posicionDeseada = LimitarPosDeCamara(posicionDeseada);
        
        transform.position = posicionDeseada + desplazamiento;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(posDeZonaVisual, tamañoDeZonaVisual);
    }
    private Vector2 TamañoDeCamara()
    {
        Vector2 tamaño;
        float size = Camera.main.orthographicSize;
        tamaño.y = size;
        tamaño.x = size * Camera.main.aspect;
        return tamaño;
    }
    private Vector2 LimitarPosicion(Vector2 posicion, Vector2 posMaxima, Vector2 posMinima)
    {
        Vector2 posLimitada;
        posLimitada.x = Mathf.Clamp(posicion.x, posMaxima.x, posMinima.x);
        posLimitada.y = Mathf.Clamp(posicion.y, posMaxima.y, posMinima.y);
        return posLimitada;
    }
    private Vector2 LimitarPosDeCamara(Vector2 posActual)
    {
        Vector2 tamañoDeLaCamara = TamañoDeCamara();
        Vector2 tamañoDelMapa = tamañoDeZonaVisual / 2;
        Vector2 centroDelMapa = posDeZonaVisual;

        Vector2 limiteMinimo = centroDelMapa - (tamañoDelMapa - tamañoDeLaCamara);
        Vector2 limiteMaximo = centroDelMapa + (tamañoDelMapa - tamañoDeLaCamara);

        return LimitarPosicion(posActual, limiteMinimo, limiteMaximo);
    }

}
