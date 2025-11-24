using TMPro;
using UnityEngine;

public class BotonDeObjetoConCantidad : BotonDeObjeto
{
    private int cantEnElSlot = 0;
    [SerializeField]
    private TMP_Text textoDeCantidad;

    void Start()
    {
        textoDeCantidad.text = cantEnElSlot.ToString();
    }

    public override bool SePuedeUsar()
    {
        return base.SePuedeUsar() && cantEnElSlot > 0;
    }

    public override void Usar(float recuperacionDeAtaque)
    {
        cantEnElSlot--;
        textoDeCantidad.text = cantEnElSlot.ToString();
        base.Usar(recuperacionDeAtaque);
    }




}
