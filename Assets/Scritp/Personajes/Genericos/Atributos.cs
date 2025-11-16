using System;
using UnityEngine;

public class Atributos : MonoBehaviour
{
    public string Nombre;
    [Min(1)]
    public int VidaMaxima;
    public int Vida;
    public int Pa;

    public int Pd;

    public float Velocidad;

    public float ExpAEntregar = 10;
    public void CopiarDesde(Atributos otros)
    {
        Nombre = otros.Nombre;
        VidaMaxima = otros.VidaMaxima;
        Vida = otros.Vida;
        Pa = otros.Pa;
        Pd = otros.Pd;
        Velocidad = otros.Velocidad;
        ExpAEntregar = otros.ExpAEntregar;
    }
}
