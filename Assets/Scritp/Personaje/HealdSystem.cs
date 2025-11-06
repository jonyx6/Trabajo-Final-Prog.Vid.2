
using UnityEngine;

[RequireComponent(typeof(Personaje))]
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
        //el max lo utilizo para que si tiene mas escudo que daño no le suba la vida
        atributos.Vida -= Mathf.Max(0,unDanio - atributos.Pd);
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
