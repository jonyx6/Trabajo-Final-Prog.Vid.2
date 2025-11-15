
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Personaje))]
[RequireComponent(typeof(Animator))]
public class HealdSystem : MonoBehaviour,IInteractable
{
    private Atributos2 atributos;
    private Animator _animator;
    
    private void Awake()
    {
        atributos = GetComponent<Personaje>().atributos;
        _animator = GetComponent<Animator>();
    }
    public void RecibirUn_(float unDanio)
    {
        Debug.Log("Recibio da�o");
        //el max lo utilizo para que si tiene mas escudo que daño no le suba la vida
        Debug.Log("daño recibido "+ unDanio +"defensa"+ atributos.Pd);
        atributos.Vida -= Mathf.Max(0,unDanio - atributos.Pd);
        _animator.SetTrigger("isHurt");
        Debug.Log(atributos.Vida);

        if(atributos.Vida < 1)
        {
            _animator.SetBool("isDeath",true);
            StartCoroutine(GameOver());
            //Destroy(gameObject);
        }
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

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    


}
