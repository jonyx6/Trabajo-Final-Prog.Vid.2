using UnityEngine.UI;
using UnityEngine;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private SistemaDeSalud SistemaDeSalud;
    // Start is called before the first frame update
    void Start()
    {
        SistemaDeSalud.onHealthChange += RenderizarVida;
    }

    private void RenderizarVida(float vida,float vidaMaxima)
    {
        image.fillAmount = vida /vidaMaxima;
    }
}
