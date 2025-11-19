using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour, IDamager
{
    [SerializeField]
    private Atributos _atributos;
    [SerializeField]
    private LevelSystem _levelSystem;
    private void Start() {
        _atributos = GetComponentInParent<Atributos>();
        _levelSystem = GetComponentInParent<LevelSystem>();
    }

    float IDamager.Damage()
    {
        return _atributos.Pa;
    }

    public void DarXP(float expAEntregar)
    {
        if(_levelSystem != null)
        {
            _levelSystem.SubirExperiencia(expAEntregar);
        }
    }
}
