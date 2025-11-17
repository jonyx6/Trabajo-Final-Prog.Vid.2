using UnityEngine.UI;
using UnityEngine;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Atributos atributos;
    // Start is called before the first frame update
    void Start()
    {
        //atributos.onVidaChange += RenderizarVida;
    }

    private void RenderizarVida(float vida,float vidaMaxima)
    {
        image.fillAmount = vida /vidaMaxima;
    }
}
