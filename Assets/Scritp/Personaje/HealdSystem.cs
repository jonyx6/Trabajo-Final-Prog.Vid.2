using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealdSystem : MonoBehaviour,IInteractable
{
    private Atributos aPlayer;
    
   

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

    public void Interact(LevelSystem unPersonaje)
    {
        

        unPersonaje.SubirExperiencia(aPlayer.ExpAEntregar);
    }


    public void Morir(LevelSystem unPersonaje)
    {
        if(aPlayer.Vida < 1)
        {
            Interact(unPersonaje);
            Destroy(gameObject);
            
        }
    }

    


}
