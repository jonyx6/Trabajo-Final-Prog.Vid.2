using UnityEngine;

public class BarraDeStamina : BarraDeEstadisticas

{
    
    private void Start()
    {
        
        StaminaSystem sCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<StaminaSystem>();
        Atributos atributosDelJugador = ObtenerAtributosDeJugador();
        DibujarBarra(sCharacter.estamiaActual, atributosDelJugador.EstaminaMax);
        sCharacter.OnStaminaChange += DibujarBarra;


    } 
}
