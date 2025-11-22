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
    //aca se asigna si es un PlayerDamager(que daña enemigos)
    //o un EnemyDamager (que daña jugadores)
    [SerializeField]
    private string layerDelProyectil;
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
        GameObject proyectil = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        
        AsignarPropiedadesAProyectil(proyectil);
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

        proyectil.layer = LayerMask.NameToLayer(layerDelProyectil);

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
}