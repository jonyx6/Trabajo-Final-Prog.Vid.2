using System;
using UnityEngine;

public enum TipoDeAtributo
{
    VidaMaxima,
    Vida,
    Pa,
    Pd,
    Velocidad,
}
public class Atributos : MonoBehaviour
{
    public string Nombre;
    //public event Action onChangeName;
    [Min(1)]
    public float VidaMaxima;
    //public event Action onChangeVidaMaxima;
    public float Vida;
    //public event Action onChangeVida;
    public float Pa;

    public float Pd;

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
    public void AumentarAtributo(TipoDeAtributo atributo,float cantidad)
    {
        switch (atributo)
        {
            case TipoDeAtributo.Pa:
                Pa += Mathf.FloorToInt(cantidad);
                break;
            case TipoDeAtributo.Pd:
                Pd += Mathf.FloorToInt(cantidad);
                break;
            case TipoDeAtributo.Velocidad:
                Velocidad += cantidad;
                break;
            case TipoDeAtributo.Vida:
                Vida += Mathf.FloorToInt(cantidad);
                break;
            case TipoDeAtributo.VidaMaxima:
                VidaMaxima += Mathf.FloorToInt(cantidad);
                break;
            default:
                break;
        }
    }
}
