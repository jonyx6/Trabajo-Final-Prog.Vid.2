using UnityEngine.UI;
using UnityEngine;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Atributos _atributos;
    // Start is called before the first frame update
    void Start()
    {
        image.fillAmount = _atributos.Vida / _atributos.VidaMaxima;
        _atributos.OnVidaChange += RenderizarVida;
    }

    private void RenderizarVida(float vida,float vidaMaxima)
    {
        image.fillAmount = vida /vidaMaxima;
    }
}
