using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour, IDamager
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
        _levelSystem.SubirExperiencia(expAEntregar);
    }
    public void ChorearEvento(Action Evento)
    {
        
    }
}
