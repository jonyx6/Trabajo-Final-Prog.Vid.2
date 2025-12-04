using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ataque
{
    public abstract void Ejecutar();
    public abstract void Entrar();
    public abstract void Salir();
    public void CambiarA(Ataque otroAtaque)
    {
        Salir();
        otroAtaque.Entrar();
    }
}
