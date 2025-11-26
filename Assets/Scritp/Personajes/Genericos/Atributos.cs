using System;
using UnityEngine;

public enum TipoDeAtributo
{
    VidaMaxima,
    Vida,
    Pa,
    Pd,
    Velocidad,
    EstaminaMax
}


public class Atributos : MonoBehaviour
{


    
    public string Nombre;
    //public event Action onChangeName;
    [field: SerializeField, Min(1)]
    public float VidaMaxima { get; set; }

    [field: SerializeField]
    public float Vida { get;  set; }
   
    //public event Action onChangeVida;
    public float Pa;

    public float Pd;

    public float Velocidad;

    public float ExpAEntregar = 10;

    public float EstaminaMax = 10;

    public float cantDeRecuperacion;

    private SistemaDeSalud ssCharacter;


    private void Start()
    {
        ssCharacter = GetComponent<SistemaDeSalud>();
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
        EstaminaMax = otros.EstaminaMax;
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
                ssCharacter.CambiarVida(Vida + cantidad);
                break;
            case TipoDeAtributo.VidaMaxima:
                ssCharacter.CambiarVidaMaxima(VidaMaxima + cantidad);
                break;
            case TipoDeAtributo.EstaminaMax:
                EstaminaMax += cantidad;
                break;
                
            default:
                break;
        }
    }
}
