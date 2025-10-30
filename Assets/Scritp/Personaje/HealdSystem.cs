using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealdSystem : MonoBehaviour
{
    private Atributos aPlayer;
    //private bool estaVivo = true;
   

    private void Awake()
    {
        aPlayer = GetComponent<Atributos>();
    }
    public void RecibirUn_(int unDanio)
    {
        Debug.Log("Recibio daño");
        aPlayer.Vida -= (unDanio - aPlayer.Pd);
    }

    public void AumentarVida(int cantVida)
    {
        aPlayer.Vida += cantVida;
    }

    public void Morir()
    {
        if(aPlayer.Vida < 1)
        {
            //estaVivo=false;
            Destroy(gameObject);
            
        }
    }


}
