using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraContoller : MonoBehaviour
{
    [SerializeField]
    private Transform objetivo;
    [SerializeField]
    private float velocidadCamara = 0.025f;
    [SerializeField]
    private Vector3 desplazamiento;
    [Header("Limites de la camara")]
    [SerializeField]
    private Vector2 tamañoDeZonaVisual;
    [SerializeField]
    private Vector2 posDeZonaVisual;
    private Camera _camera;
    [Header("Zoom")]
    [SerializeField]
    private float zoomMinimo = 4;
    [SerializeField]
    private float zoomMaximo = 10;
    [SerializeField]
    private float velocidadDeZoom = 10;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }
    private void Update()
    {
        if (objetivo != null)
        {
            MoverCamara();
            HacerZoom();
        }

    }
    private void HacerZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            _camera.orthographicSize -= scroll * velocidadDeZoom;  // Ajusta el zoom
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, zoomMinimo, zoomMaximo);
        }
    }
    private void MoverCamara()
    {
        Vector3 posicionDeseada = objetivo.position;

        posicionDeseada = Vector3.Lerp(transform.position, posicionDeseada, velocidadCamara * Time.deltaTime);

        posicionDeseada = LimitarPosDeCamara(posicionDeseada);

        transform.position = posicionDeseada + desplazamiento;
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(posDeZonaVisual, tamañoDeZonaVisual);
    }
}
