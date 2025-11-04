using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int Nivel = 1;
    public float expActual = 0f;
    public float limitDelNivel = 100f;

    public void SubirDeNivel()
    {
        if (expActual >= limitDelNivel)
        {
            Nivel += 1;
            
            expActual = ResultadoExperienciaFinal();
            limitDelNivel *= 1.25f;
        }

    }

    float  ResultadoExperienciaFinal()
    {
        return expActual - limitDelNivel;
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
