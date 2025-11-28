using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour,IDamager
{
    [SerializeField]
    private float daño;
    public float Damage()
    {
        return daño;
    }

    public void DarXP(float expAEntregar)
    {
        
    }
}
