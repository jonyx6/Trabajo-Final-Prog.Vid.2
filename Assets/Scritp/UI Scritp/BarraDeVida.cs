using UnityEngine;

public class BarraDeVida : BarraDeEstadisticas
{
     private void Start()
     {
         //obtenemos el componente atributos del jugador
         SistemaDeSalud _sistemaDeSalud = GameObject.FindGameObjectWithTag("Player").GetComponent<SistemaDeSalud>();

         Atributos _AtributosDelJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Atributos>();

         //dibujamos la vida que tiene al inicio
         DibujarBarra(_AtributosDelJugador.Vida, _AtributosDelJugador.VidaMaxima);// funcion que hereda de la clase padre.

         //este evento es invocado cuando cambia la vida
         //nos suscribimos a el para saber cuando hay que dibujar la barra de vida
         _sistemaDeSalud.OnVidaChange += DibujarBarra;

         //la barra de vida solo se dibuja cuando empieza y cuando cambia la vida no hace falta dibujarla en el update
     } 

   
}
