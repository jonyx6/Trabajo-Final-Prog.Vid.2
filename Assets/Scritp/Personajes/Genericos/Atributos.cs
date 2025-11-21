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
    [field: SerializeField, Min(1)]
    public float VidaMaxima { get; private set; }

    [field: SerializeField]
    public float Vida { get; private set; }
    public event Action<float, float> OnVidaChange;
    //public event Action onChangeVida;
    public float Pa;

    public float Pd;

    public float Velocidad;

    public float ExpAEntregar = 10;
    
    public void CambiarVida(float nuevaVida)
    {
        Vida = nuevaVida;
        OnVidaChange?.Invoke(Vida, VidaMaxima);
    }
    public void CambiarVidaMaxima(float nuevaVida)
    {
        VidaMaxima = nuevaVida;
        OnVidaChange?.Invoke(Vida, VidaMaxima);
    }

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
    public void AumentarAtributo(TipoDeAtributo atributo, float cantidad)
    {
        switch (atributo)
        {
            case TipoDeAtributo.Pa:
                Pa += cantidad;
                break;
            case TipoDeAtributo.Pd:
                Pd += cantidad;
                break;
            case TipoDeAtributo.Velocidad:
                Velocidad += cantidad;
                break;
            case TipoDeAtributo.Vida:
                CambiarVida(Vida + cantidad);
                break;
            case TipoDeAtributo.VidaMaxima:
                CambiarVidaMaxima(VidaMaxima + cantidad);
                break;
            default:
                break;
        }
    }
}
