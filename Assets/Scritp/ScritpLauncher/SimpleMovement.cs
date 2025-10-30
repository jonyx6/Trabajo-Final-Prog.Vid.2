using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SimpleMovement : MonoBehaviourPunCallbacks//
{
    public Atributos aPersonaje;// la velocidad la saco de los atributos

    void Update()
    {
        if (photonView.IsMine)//de esta manera sabe en cada instancia cual es el jugador que se instancio por tanto solo movemos ese
        {
            float movimienHorizontal = Input.GetAxis("Horizontal");
            float movimientoVerticla = Input.GetAxis("Vertical");

            Vector3 desplazamiento = new Vector3(movimienHorizontal, movimientoVerticla)*aPersonaje.Velocidad*Time.deltaTime;

            transform.Translate(desplazamiento);
        }
        
    }
}
