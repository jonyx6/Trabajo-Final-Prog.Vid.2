using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LevelSystem))]
public class PlayerActorView : ActorView
{
    private ParticulasDeJugador _particleSystem;
    private LevelSystem _levelSystem;
    protected override void Awake() {
        base.Awake();
        _particleSystem = GetComponentInChildren<ParticulasDeJugador>();
        _levelSystem = GetComponent<LevelSystem>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        _systemHealth.OnHeal += _particleSystem.MostrarParticulasDeVida;
        _levelSystem.OnLevelUp += _particleSystem.MostrarParticulasDeNivel;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        _systemHealth.OnHeal -= _particleSystem.MostrarParticulasDeVida;
        _levelSystem.OnLevelUp -= _particleSystem.MostrarParticulasDeNivel;
    }
}
