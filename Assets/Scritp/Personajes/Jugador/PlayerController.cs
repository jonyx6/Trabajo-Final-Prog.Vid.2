using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Atributos))]
public class PlayerController : MonoBehaviour
{
    Atributos atributosDelJugador;
    private void Start()
    {
        atributosDelJugador = GetComponent<Atributos>();
        if (GameManager.Instance.tieneAtributos)
        {
            atributosDelJugador.CopiarDesde(GameManager.Instance.atributosGuardados);
        }

        GameManager.Instance.tieneAtributos = true;
        GameManager.Instance.atributosGuardados.CopiarDesde(atributosDelJugador);
    }
}
