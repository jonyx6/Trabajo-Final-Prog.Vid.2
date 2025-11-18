using UnityEngine.UI;
using UnityEngine;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField]
    private Image image;
    private Atributos atributosDelJugador;
    // Start is called before the first frame update
    void Start()
    {
        ObtenerAtributosDeJugador();
        RenderizarVida(atributosDelJugador.Vida,atributosDelJugador.VidaMaxima);
        atributosDelJugador.OnVidaChange += RenderizarVida;
    }
    public void ObtenerAtributosDeJugador()
    {
        atributosDelJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Atributos>();
    }

    private void RenderizarVida(float vida,float vidaMaxima)
    {
        image.fillAmount = vida /vidaMaxima;
    }
}
