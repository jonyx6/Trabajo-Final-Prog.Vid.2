using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int Nivel = 0;
    public float expActual = 0f;
    public float limitDelNivel = 100f;
    public Atributos atributos;
    public float porcentajeDeAumentoDeAtributos=0.1f;


    void Start()
    {
        atributos = GetComponent<Atributos>();
    }


    public void SubirDeNivelSiPuede()
    {
        if (expActual >= limitDelNivel)
        {
            expActual -= limitDelNivel;
            Nivel ++;
            AumentarAtributos(porcentajeDeAumentoDeAtributos);
        }

    }


    public void AumentarAtributos(float unaCant)
    {
        limitDelNivel *= 1+unaCant;
        atributos.Pa *= 1+unaCant ;
        atributos.Vida *=1+ unaCant ;
        atributos.Pd *= 1+unaCant ;
        atributos.Velocidad *= 1+unaCant;
        atributos.ExpAEntregar *= 1+ unaCant;
    }



    public void SubirExperiencia(float unCantDeExp)
    {
        expActual += unCantDeExp;

        SubirDeNivelSiPuede();

    }
}
