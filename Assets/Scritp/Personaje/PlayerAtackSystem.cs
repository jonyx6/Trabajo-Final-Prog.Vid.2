using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PlayerAtackSystem : AttackSystem
{
    [SerializeField]
    private Image boton3;
    [SerializeField]
    private Image boton1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && boton3.fillAmount == 1)
        {
            AtaqueSimple();
        }
        
        if (Input.GetKeyDown(KeyCode.W) && boton1.fillAmount == 1)
        {
            AtaqueEspecial();
        }
    }

}