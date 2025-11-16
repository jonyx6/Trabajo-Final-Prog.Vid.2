using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoFlee<T> : State<T>
{
    private Transform _target;
    private float _maxSpeed;
    private float _fleeSpeed;
    private float _rotSpeed;
    private Agent_FSM_Controller _controller;

    public EstadoFlee(T stateID, Transform NPCAgent, Agent_FSM_Controller controller, FSM<T> fsm, Transform target, float maxSpeed, float rotSpeed)
        : base(stateID, NPCAgent, fsm)
    {
        _target = target;
        _maxSpeed = maxSpeed;
        _rotSpeed = rotSpeed;
        _controller = controller;
    }


    public override void Enter()
    {
        base.Enter();
        _fleeSpeed = _maxSpeed;
    }

    public override void Execute()
    {
        base.Execute();

        if (_target != null)
        {
            Vector3 direction = (_agentTransform.position - _target.position).normalized;
            _agentTransform.position += direction * _fleeSpeed * Time.deltaTime;

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

    override public void CheckConditions()
    {
        if (!_controller.CanFlee())
        {
            _controller.SetIdle();
        }
    }

    public override void Sleep()
    {
        base.Sleep();

    }
}