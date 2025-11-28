using System;
using System.Collections;
using UnityEngine;
//esta clase se encarga de disparar un proyectil
//se asigna a cualquier personaje que quieras que dispare
public class ShooterSystem : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    private LevelSystem levelSystem;
    private Atributos atributos;
    public Transform objetivo;
    private void Start() {
        levelSystem = GetComponent<LevelSystem>();
        atributos = GetComponent<Atributos>();
    }
    /* 
        la funcion shoot se encarga de crear un proyectil y asignarle cosas como:
        su posicion
        su rotacion
        el layer al que pertenece
        el daño que se le podria agregar
        y una forma para recibir xp si el projectil logra matar
     */
    public void Shoot()
    {
        //GameObject proyectil = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        DispararHaciaAdelante();
       // AsignarPropiedadesAProyectil();
    }
    /*
        cosas como:
        el layer al que pertenece
        el daño que se le podria agregar
        y una suscripcion al evento si el projectil logra matar
     */
    private void AsignarPropiedadesAProyectil(GameObject proyectil)
    {
        Proyectile scriptDeProyectil =  proyectil.GetComponent<Proyectile>();

        //si el personaje tiene atributos aumenta el daño del proyectil segun pa
        if(atributos != null)
        {
            scriptDeProyectil.AumentarDaño(atributos.Pa);
        }

        //si el personaje tiene sistema de nivel se suscribe al evento recibir xp del proyectil
        if(levelSystem != null)
        {
            scriptDeProyectil.AlRecibirXp += levelSystem.SubirExperiencia;
            //pasados 5 seg se desuscribe
            //al final no hace falta desuscribirse por que se elimina
        }
    }


    //jony funcions disparar enemigo.

    public void Disparar()
    {
        DispararAObjetivo(objetivo.position);
    }


    public void DispararAObjetivo(Vector3 _target)
    {
        // Dirección hacia el objetivo
        Vector2 direccion = (_target - shootPoint.position).normalized;

        // Ángulo para rotar la flecha
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Instanciamos la flecha con la rotación correcta
        GameObject proyectil = Instantiate(
            arrowPrefab,
            shootPoint.position,
            Quaternion.Euler(0f, 0f, angulo)
        );


        


        // Le damos velocidad en la dirección calculada
      
        proyectil.GetComponent<Rigidbody2D>().velocity = direccion * 1;
        
    }

    // funciones de fran pruebas

    public void DispararHaciaAdelante()
    {
        DispararHacia(transform.right);
    }
    public void DispararHacia(Vector3 direccion)
    {
        GameObject proyectil = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        proyectil.GetComponent<Proyectile>().LanzarBala(direccion);
    }


}