using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeVidaEnemigo : MonoBehaviour
{
    [SerializeField]
    private float tamañoDeBarra = 0.1f;
    [SerializeField]
    private SistemaDeSalud sistemaDeSalud;
    [SerializeField]
    private Atributos atributos;
    void Start()
    {
        ActualizarBarraDeVida(atributos.Vida,atributos.VidaMaxima);
        sistemaDeSalud.OnVidaChange += ActualizarBarraDeVida;
    }
    void OnDestroy()
    {
        sistemaDeSalud.OnVidaChange -= ActualizarBarraDeVida;
    }

    private void ActualizarBarraDeVida(float vida,float vidaMaxima)
    {
        transform.localScale = new Vector2(vida*tamañoDeBarra,transform.localScale.y);
    }
}
