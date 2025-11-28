using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMEnemy2 : MonoBehaviour 
{

    private FSM<EstadosDeLaIA> _fsm;

    [SerializeField]
    private float _chaseSpeed ;
    [SerializeField]
    private float _fleeSpeed ;
    [SerializeField]
    private float _rotSpeed ;

    public Animator _animator;

    public Transform _target;

    private Atributos _atributos;

    private SistemaDeSalud _sistemaDeSalud;

    private InSightViewPro _inSightView;

    
    private float healthForFlee ;

    private void Awake()
    {
        _sistemaDeSalud = GetComponent<SistemaDeSalud>();
        _atributos = GetComponent<Atributos>();
        _inSightView = GetComponent<InSightViewPro>();
        _animator = GetComponent<Animator>();

        healthForFlee = _atributos.VidaMaxima/2;
        _chaseSpeed = _atributos.Velocidad;
        _fleeSpeed = _atributos.Velocidad * 2;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        InitializationFSM();
    }

    public void InitializationFSM()
    {
        _fsm = new FSM<EstadosDeLaIA>();

        IdleStateEnemy2<EstadosDeLaIA> idle = new IdleStateEnemy2<EstadosDeLaIA>(EstadosDeLaIA.Idle, transform, this, _fsm);
        FleeStateEnemy2<EstadosDeLaIA> flee = new FleeStateEnemy2<EstadosDeLaIA>(EstadosDeLaIA.Flee, transform, this, _fsm, _target, _fleeSpeed, _rotSpeed);
        ChaseStateEnemy2<EstadosDeLaIA> chase = new ChaseStateEnemy2<EstadosDeLaIA>(EstadosDeLaIA.Chase, transform, this, _fsm,_inSightView,_chaseSpeed,_rotSpeed);
        AttackStateEnemy2<EstadosDeLaIA> atacar = new AttackStateEnemy2<EstadosDeLaIA>(EstadosDeLaIA.attack, transform, this, _fsm);





        idle.AddTransition(EstadosDeLaIA.Flee, flee);
        idle.AddTransition(EstadosDeLaIA.Chase, chase);
        idle.AddTransition(EstadosDeLaIA.attack, atacar);

        flee.AddTransition(EstadosDeLaIA.Idle, idle);
        flee.AddTransition(EstadosDeLaIA.Chase, chase);
        flee.AddTransition(EstadosDeLaIA.attack, atacar);

        chase.AddTransition(EstadosDeLaIA.Idle, idle);
        chase.AddTransition(EstadosDeLaIA.Flee, flee);
        chase.AddTransition(EstadosDeLaIA.attack, atacar);

       
        atacar.AddTransition(EstadosDeLaIA.Chase, chase);
        atacar.AddTransition(EstadosDeLaIA.Flee, flee);
        atacar.AddTransition(EstadosDeLaIA.Idle, idle);

        _fsm.SetInit(idle);
    }

    private void Update()
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

    public bool siElEnemigoEstaSerca()
    {
        return _inSightView.EstaCerca();
    }


}
