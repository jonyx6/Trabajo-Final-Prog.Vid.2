using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour, IDamager
{
    [SerializeField]
    private Atributos _atributos;
    private void Start() {
        _atributos = GetComponentInParent<Atributos>();
    }

    int IDamager.Damage()
    {
        return _atributos.Pa;
    }
}
