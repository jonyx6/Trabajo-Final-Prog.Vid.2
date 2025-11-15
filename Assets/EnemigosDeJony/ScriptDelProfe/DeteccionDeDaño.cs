using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeDaños : MonoBehaviour
{
    private IDamager dañadorActual;
    [SerializeField]
    private float intervaloDeDanio = 0.5F;
    private SistemaDeSalud _sistemaDeSaludPersoaje;

    private void Awake()
    {
        _sistemaDeSaludPersoaje = GetComponent<SistemaDeSalud>();
    }


    public IEnumerator AplicarDanioConCorutine()
    {
        while (true)
        { 
            if(dañadorActual != null) // si exite un daño actual
            {
                _sistemaDeSaludPersoaje.Recibir_(dañadorActual.Damage);

                yield return new WaitForSeconds(intervaloDeDanio);
            }
        
        
        }
    }
}