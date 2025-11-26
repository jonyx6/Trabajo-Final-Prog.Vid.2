using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Boss_Fms_Controller : MonoBehaviour
{
    private FSM<EstadosDeLaIA> _fsm;// jony: podemos intentar hacer otro enum con mas estados

    [SerializeField]
    private float _chaseSpeed = 10f;
    [SerializeField]
    private float _fleeSpeed = 10f;
    [SerializeField]
    private float _rotSpeed = 10f;

    public Animator _animator;

    public Transform _target;

    private Atributos _atributos;

    private SistemaDeSalud _sistemaDeSalud;// cuestionar el uso

    private InSightViewPro _inSightView;

    [SerializeField]
    private float healthForFlee = 9f;

    private void Awake()
    {
        _sistemaDeSalud = GetComponent<SistemaDeSalud>();
        _atributos = GetComponent<Atributos>();
        _inSightView = GetComponent<InSightViewPro>();
        _animator = GetComponent<Animator>();

    }

    void Start()
    {
        InitializationFSM();
    }

    public void InitializationFSM()
    {
        _fsm = new FSM<EstadosDeLaIA>();
        BossIdleState<EstadosDeLaIA> idle = new BossIdleState<EstadosDeLaIA>(EstadosDeLaIA.Idle, transform, this, _fsm);
        BossFleeState<EstadosDeLaIA> flee = new BossFleeState<EstadosDeLaIA>(EstadosDeLaIA.Flee, transform, this, _fsm, _target, _fleeSpeed, _rotSpeed);
        BossChaseState<EstadosDeLaIA> chase = new BossChaseState<EstadosDeLaIA>(EstadosDeLaIA.Chase, transform, this, _fsm, _inSightView, _chaseSpeed, _rotSpeed);
        BossAttackState<EstadosDeLaIA> atacar = new BossAttackState<EstadosDeLaIA>(EstadosDeLaIA.attack, transform, this, _fsm);


        idle.AddTransition(EstadosDeLaIA.Flee, flee);
        idle.AddTransition(EstadosDeLaIA.Chase, chase);

        flee.AddTransition(EstadosDeLaIA.Idle, idle);
        flee.AddTransition(EstadosDeLaIA.Chase, chase);

        chase.AddTransition(EstadosDeLaIA.Idle, idle);
        chase.AddTransition(EstadosDeLaIA.Flee, flee);
        chase.AddTransition(EstadosDeLaIA.attack, atacar);

        //jony: creo una nueva trancision
        atacar.AddTransition(EstadosDeLaIA.attack, atacar);
        atacar.AddTransition(EstadosDeLaIA.Chase, chase);
        atacar.AddTransition(EstadosDeLaIA.Flee, flee);

        _fsm.SetInit(idle);
    }

    void Update()
    {
        _fsm.OnUpdate();
    }

    public bool CanChase()
    {
        return _inSightView.EstaAlaVista();
    }

    public bool CanFlee()
    {
        return _inSightView.EnRango() && _atributos.Vida < healthForFlee;
    }
    public void SetIdle()
    {

        _fsm.ChangeState(EstadosDeLaIA.Idle);
    }

    public bool PuedeAtacar()
    {
        return _inSightView.EstaCerca();
    }

    public void SetearAtaque()
    {
        _fsm.ChangeState(EstadosDeLaIA.attack);
    }

    public void SetChase()
    {
        _fsm.ChangeState(EstadosDeLaIA.Chase);
    }

    public void SetFlee()
    {
        _fsm.ChangeState(EstadosDeLaIA.Flee);
    }
}
