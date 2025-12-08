using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeVidaBoos : BarraDeEstadisticas
{
    [SerializeField]
    private Atributos atributosDeBoss;
    [SerializeField]
    private SistemaDeSalud sistemaDeSaludDeBoss;
    void Start()
    {
        CambiarRellenoDeBarraSegun(atributosDeBoss.Vida, atributosDeBoss.VidaMaxima);// funcion que hereda de la clase padre.

        sistemaDeSaludDeBoss.OnVidaChange += CambiarRellenoDeBarraSegun;
    }
}
