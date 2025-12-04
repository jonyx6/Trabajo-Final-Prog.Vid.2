using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class AtaqueBasico : Ataque
{
    public override void Ejecutar()
    {
        Debug.Log("Se ejecuta ataque 1");
    }

    public override void Entrar()
    {
        Debug.Log("Entra ataque 1");
    }

    public override void Salir()
    {
        Debug.Log("Sale ataque 1");
    }
}
