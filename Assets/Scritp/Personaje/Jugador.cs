using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : Personaje
{
    private void Start() {
        atributos = GameManager.Instance.AtributosDelJugador;
    }
}
