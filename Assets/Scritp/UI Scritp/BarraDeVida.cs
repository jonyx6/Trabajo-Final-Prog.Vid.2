using UnityEngine.UI;
using UnityEngine;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField]
    private Image rellenoDeBarraDeVida;
    [SerializeField]
    private float MultiplicadorDeAncho = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //obtenemos el componente atributos del jugador
        Atributos atributosDelJugador = ObtenerAtributosDeJugador();

        //dibujamos la vida que tiene al inicio
        DibujarVida(atributosDelJugador.Vida,atributosDelJugador.VidaMaxima);

        //este evento es invocado cuando cambia la vida
        //nos suscribimos a el para saber cuando hay que dibujar la barra de vida
        atributosDelJugador.OnVidaChange += DibujarVida;

        //la barra de vida solo se dibuja cuando empieza y cuando cambia la vida no hace falta dibujarla en el update
    } 
    private Atributos ObtenerAtributosDeJugador()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<Atributos>();
    }

    private void DibujarVida(float vida,float vidaMaxima)
    {
        CambiarAnchoDeBarraSegun(vidaMaxima);
        CambiarRellenoDeBarraSegun(vida,vidaMaxima);
    }
    private void CambiarAnchoDeBarraSegun(float vidaMaxima)
    {
        float anchoDeBarra = vidaMaxima * MultiplicadorDeAncho;
        transform.localScale = new Vector2(anchoDeBarra,transform.localScale.y);
    }
    private void CambiarRellenoDeBarraSegun(float vida,float vidaMaxima)
    {
        rellenoDeBarraDeVida.fillAmount = vida /vidaMaxima;
    }
}
