using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int Nivel = 0;
    public float expActual = 0f;
    public float limitDelNivel = 100f;
    public Atributos aPersonaje;
    public float porcentajeDeAumentoDeAtributos=0.1f;

 



    public void SubirDeNivel()
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
        aPersonaje.Pa *= 1+unaCant ;
        aPersonaje.Vida *=1+ unaCant ;
        aPersonaje.Pd *= 1+unaCant ;
        aPersonaje.Velocidad *= 1+unaCant;
        aPersonaje.ExpAEntregar *= 1+ unaCant;
    }



    public void SubirExperiencia(float unCantDeExp)
    {
        expActual += unCantDeExp;

    }

    private void Update()
    {

        SubirDeNivel();
    }


}
