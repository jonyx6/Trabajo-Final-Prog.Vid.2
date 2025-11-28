using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MenuPausa : MonoBehaviour
{
    public GameObject panel;
    public bool juegoPausado = false;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
               
            }
            else
            {
                
                Pausar();
            }


        }
    }



    public void Reanudar()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
    }

    public void Pausar()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;

    }
}
