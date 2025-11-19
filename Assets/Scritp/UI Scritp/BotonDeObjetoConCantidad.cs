using TMPro;
using UnityEngine;

public class BotonDeObjetoConCantidad : BotonDeObjeto
{
    public int UsosRestantes;

    [SerializeField]
    private TMP_Text textoDeCantidad;

    void Start()
    {
        textoDeCantidad.text = UsosRestantes.ToString();
    }

    public override bool SePuedeUsar()
    {
        return base.SePuedeUsar() && UsosRestantes > 0;
    }

    public override void Usar(float recuperacionDeAtaque)
    {
        UsosRestantes--;
        textoDeCantidad.text = UsosRestantes.ToString();
        base.Usar(recuperacionDeAtaque);
    }
}
