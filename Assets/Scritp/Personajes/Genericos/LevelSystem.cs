using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int Nivel = 0;
    public float expActual = 0f;
    public float limitDelNivel = 100f;
    private Atributos atributos;
    public float porcentajeDeAumentoDeAtributos = 0.1f;
    private SistemaDeSalud _ssPlayer;


    void Start()
    {
        atributos = GetComponent<Atributos>();
        _ssPlayer = GetComponent<SistemaDeSalud>();
    }


    public void SubirDeNivelSiPuede()
    {
        while (expActual >= limitDelNivel)
        {
            expActual -= limitDelNivel;
            Nivel ++;
            NotificationSystem.Instance.ShowMessage("has subido de nivel",Nivel);
            AumentarAtributos(porcentajeDeAumentoDeAtributos);
        }

    }


    public void AumentarAtributos(float unaCant)
    {
        limitDelNivel *= 1+unaCant;
        atributos.Pa *= 1+unaCant ;
        _ssPlayer.CambiarVida(atributos.Vida * (1 + unaCant));
        _ssPlayer.CambiarVidaMaxima(atributos.VidaMaxima * (1 + unaCant));
        atributos.Pd *= 1+unaCant ;
        atributos.Velocidad *= 1+unaCant;
        atributos.ExpAEntregar *= 1+ unaCant;
        atributos.EstaminaMax *= 1+ unaCant;
        atributos.cantDeRecuperacion *= 1 + unaCant;
    }



    public void SubirExperiencia(float unCantDeExp)
    {
        expActual += unCantDeExp;
        NotificationSystem.Instance.ShowMessage("+"+unCantDeExp+" XP",2);

        SubirDeNivelSiPuede();

    }
}
