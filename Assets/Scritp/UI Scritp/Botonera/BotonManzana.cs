using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class botonManzanas : BotonDeObjeto
{
    // jony botonera
    private int cantDeManzanas = 0;
    [SerializeField]
    private TMP_Text textoDeCantidad;

    void Start()
    {
        textoDeCantidad.text = cantDeManzanas.ToString();
    }

    public override bool SePuedeUsar()
    {
        return base.SePuedeUsar() && cantDeManzanas > 0;
    }

    public override void Usar(float recuperacionDeAtaque)
    {
        cantDeManzanas--;
        textoDeCantidad.text = cantDeManzanas.ToString();
        base.Usar(recuperacionDeAtaque);
    }

    public void ActualizarTexto()
    {
        textoDeCantidad.text = cantDeManzanas.ToString();
    }
}
