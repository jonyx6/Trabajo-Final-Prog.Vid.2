using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDePausa : MonoBehaviour
{
    [SerializeField]
    private Canvas panelPausa;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelPausa.enabled = !panelPausa.enabled;


        }
    }
}
