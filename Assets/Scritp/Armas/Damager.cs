using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour, IDamager
{
    [SerializeField]
    private float Damage;

    float IDamager.Damage()
    {
        return Damage;
    }
}
