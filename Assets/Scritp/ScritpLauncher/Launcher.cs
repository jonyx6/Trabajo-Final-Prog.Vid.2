using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;// AÑADIMOS LA LIBRERIA Photon.Pun

public class Launcher : MonoBehaviourPunCallbacks
{
    [Header("componente del jugador ")]
    public PhotonView playerPrefab;

    [Header("Punto De Spawn Del Personaje")]

    public Transform spawnPoint;

    private void Start()
    {
        //inicializa alagunas cosas para que se pueda ingresar dentro del servidor.
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Nos CONECTAMOS AL MASTER");
        PhotonNetwork.JoinRandomOrCreateRoom();// FUNCION QUE BUSCA UNA SALA Y SI NO LA ENCUENTRA LA VA A CREAR    
    }

    public override void OnJoinedRoom()// funcion que realiza las cosas una ves que estemos en la sala 
    {
        PhotonNetwork.Instantiate(playerPrefab.name,spawnPoint.position,spawnPoint.rotation);// en este caso va a instanciar al personaje ;
    }

}

