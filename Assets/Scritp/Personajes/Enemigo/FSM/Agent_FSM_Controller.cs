
using System;
using UnityEngine;

public class Agent_FSM_Controller : MonoBehaviour
{
    private FSM<EstadosDeLaIA> _fsm;

    [SerializeField]
    private Transform _target;

    private bool isDeath => _atributos.Vida < 1;

    [SerializeField]
    private float _chaseSpeed = 10f;
    [SerializeField]
    private float _fleeSpeed = 10f;
    [SerializeField]
    private float _rotSpeed = 10f;

    public Animator _animator;

    private Atributos _atributos;
    private SistemaDeSalud _sistemaDeSalud;


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
        ///Inicializar FSM
        _fsm = new FSM<EstadosDeLaIA>();
        ///Instanciamos los estados
        EstadoIdle<EstadosDeLaIA> idle = new EstadoIdle<EstadosDeLaIA>(EstadosDeLaIA.Idle, transform, this, _fsm);
        EstadoFlee<EstadosDeLaIA> flee = new EstadoFlee<EstadosDeLaIA>(EstadosDeLaIA.Flee, transform, this, _fsm, _target, _fleeSpeed, _rotSpeed);
        EstadoChase<EstadosDeLaIA> chase = new EstadoChase<EstadosDeLaIA>(EstadosDeLaIA.Chase, transform, this, _fsm, _target, _chaseSpeed, _rotSpeed);
        //jony:inicio un uevo estado
        EstadoAtacar<EstadosDeLaIA> atacar = new EstadoAtacar<EstadosDeLaIA>(EstadosDeLaIA.attack,transform,this,_fsm);

        ///Creamos la transiciones
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



        _fsm.SetInit(idle);
    }

     void Update()
    {
        if(_target != null)
        {
            _fsm.OnUpdate();   
        }
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
