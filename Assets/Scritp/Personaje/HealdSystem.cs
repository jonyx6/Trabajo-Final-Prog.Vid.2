using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealdSystem : MonoBehaviour,IInteractable
{
    private Atributos2 atributos;
    
   

    private void Awake()
    {
        atributos = GetComponent<Personaje>().atributos;
    }
    public void RecibirUn_(float unDanio)
    {
        Debug.Log("Recibio da�o");
        atributos.Vida -= (unDanio - atributos.Pd);
    }

    public void AumentarVida(int cantVida)
    {
        atributos.Vida += cantVida;
    }

    public void Interact(LevelSystem unPersonaje)
    {
        unPersonaje.SubirExperiencia(atributos.ExpAEntregar);
    }


    public void Morir(LevelSystem unPersonaje)
    {
        if(atributos.Vida < 1)
        {
            Interact(unPersonaje);
            Destroy(gameObject);
            
        }
    }

    


}
