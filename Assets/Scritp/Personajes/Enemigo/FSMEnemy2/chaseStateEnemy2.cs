using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStateEnemy2<T>: State<T>// perseguir;
{
    private FSMEnemy2 _controller;
    private float _maxSpeed;
    private float _chaseSpeed;
    private float _rotationSpeed;
    private InSightViewPro _inSightViewPro;
    

    public ChaseStateEnemy2(T stateID , Transform NPCAgent,FSMEnemy2 controller,FSM<T> fsm , InSightViewPro inSightViewPro,float maxSpeed,float rotSpeed)
        : base(stateID,NPCAgent,fsm)
    {
        _maxSpeed = maxSpeed;
        _inSightViewPro = inSightViewPro;
        _rotationSpeed = rotSpeed;
        _controller = controller;
        
    }

    public override void Enter()
    {
        base.Enter();// ejecuta la funcion del la clase base  del state

        _chaseSpeed = _maxSpeed;
       // _controller.GetComponent<Animator>().SetBool("isWalk", true);
    }

    public override void Execute()
    {
        base.Execute();
        Debug.Log(_inSightViewPro.objetivoActual);
        if (_inSightViewPro.objetivoActual != null)
        {
            Vector3 direction = (_inSightViewPro.objetivoActual.position - _agentTransform.position).normalized;
            _agentTransform.position += direction * _chaseSpeed * Time.deltaTime;

            // Volteamos el sprite segun la direccion en X
            if (direction.x < 0)
            {
                _agentTransform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else
            {
                _agentTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public override void Sleep()
    {
        base.Sleep();
       // _controller.GetComponent<Animator>().SetBool("isWalk", false);
    }

    public override void CheckConditions()
    {
     
        if (!_controller.CanChase())
            _controller.SetIdle();
        else if (_controller.CanFlee())
            _controller.SetFlee();
        else if (_controller.PuedeAtacar())
            _controller.SetearAtaque();


    }

    public Vector3 CalculateSteering()
    {
        // Direcci?n opuesta al target
        Vector3 chaseDir = (_inSightViewPro.objetivoActual.position - _agentTransform.position).normalized;

        // Queremos ir a m?xima velocidad
        Vector3 direction = chaseDir * _maxSpeed;

        // C?lculo del steering
        Vector3 steer = direction;

        return steer;
    }


}
