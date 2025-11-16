using System;
using UnityEngine;

public class Atributos : MonoBehaviour
{
    public string Nombre;
    [Min(1)]
    public float VidaMaxima;
    public float Vida;

    public float Pa;

    public float Pd;

    public float Velocidad;

    public float ExpAEntregar = 10;
}
