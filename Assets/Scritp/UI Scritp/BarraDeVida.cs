public class BarraDeVida : BarraDeEstadisticas
{
    private void Start()
    {
        //obtenemos el componente atributos del jugador
        Atributos atributosDelJugador = ObtenerAtributosDeJugador();

        //dibujamos la vida que tiene al inicio
        DibujarBarra(atributosDelJugador.Vida,atributosDelJugador.VidaMaxima);

        //este evento es invocado cuando cambia la vida
        //nos suscribimos a el para saber cuando hay que dibujar la barra de vida
        atributosDelJugador.OnVidaChange += DibujarBarra;

        //la barra de vida solo se dibuja cuando empieza y cuando cambia la vida no hace falta dibujarla en el update
    } 
}
