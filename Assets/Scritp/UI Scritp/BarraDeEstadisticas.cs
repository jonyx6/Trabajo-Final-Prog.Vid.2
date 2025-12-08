using UnityEngine;
using UnityEngine.UI;

//De aca tienen que heredar las diferentes barras como la de stamina o vida

//IMPORTANTE acordase de acer la imagen del relleno filled
public class BarraDeEstadisticas : MonoBehaviour
{
    [SerializeField]
    private Image rellenoDeBarra;
    [SerializeField]
    private float MultiplicadorDeAncho = 0.1f;

    protected Atributos ObtenerAtributosDeJugador()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<Atributos>();
    }

    protected void DibujarBarra(float estadistica,float estadisticaMax)
    {
        CambiarAnchoDeBarraSegun(estadisticaMax);
        CambiarRellenoDeBarraSegun(estadistica,estadisticaMax);
    }
    private void CambiarAnchoDeBarraSegun(float estadisticaMax)
    {
        float anchoDeBarra = estadisticaMax * MultiplicadorDeAncho;
        transform.localScale = new Vector2(anchoDeBarra,transform.localScale.y);
    }
    protected void CambiarRellenoDeBarraSegun(float estadistica,float estadisticaMax)
    {
        rellenoDeBarra.fillAmount = estadistica /estadisticaMax;
    }
}
