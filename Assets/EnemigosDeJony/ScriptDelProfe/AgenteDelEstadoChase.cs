using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgenteDelEstadoChase<T>: State<T>

{
    private Transform _target;
    private float _maxSpeed;
    private float _chaseSpeed;
    private float _rotationSpeed;
    private Agent_FSM_Controller _controller;

    public AgenteDelEstadoChase(T stateID, Transform NPCAgent, Agent_FSM_Controller controller, FSM<T> fsm, Transform target, float maxSpeed, float rotSpeed)
       : base(stateID, NPCAgent, fsm)
    {
        _target = target;
        _maxSpeed = maxSpeed;
        _rotationSpeed = rotSpeed;
        _controller = controller;
    }



    public override void Enter()
    {
        base.Enter();// ejecuta la funcion del la clase base  del state

        _chaseSpeed = _maxSpeed;
        _controller.GetComponent<Animator>().SetBool("isWalk", true);
    }

    /* public override void Execute()
      {
          base.Execute();
          // L�gica de Chase: Moverse hacia el objetivo.
          if (_target != null)
          {
              Vector3 direction = (_target.position - _agentTransform.position).normalized;
              _agentTransform.position += direction * _chaseSpeed * Time.deltaTime;

              if (direction.sqrMagnitude > 0.01f)
              {
                  // Creamos la variable que apunta en la direcci�n de movimiento
                  Vector3 dir = new Vector3(direction.x, direction.y, 0).normalized;

                  // Creamos la rotaci�n objetivo
                  Quaternion targetRotation = Quaternion.FromToRotation(Vector3.right, dir);

                  // Rotaci�n suave
                  _agentTransform.rotation = Quaternion.RotateTowards(_agentTransform.rotation, targetRotation, _rotationSpeed);
              }
          }


      }*/

    public override void Execute()
    {
        base.Execute();
        if (_target != null)
        {
            Vector3 direction = (_target.position - _agentTransform.position).normalized;
            _agentTransform.position += direction * _chaseSpeed * Time.deltaTime;

            // Volteamos el sprite seg�n la direcci�n en X
            SpriteRenderer sr = _agentTransform.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                if(direction.x < 0)
                {
                    _agentTransform.rotation = Quaternion.Euler(0,-180,0);
                }
                else
                {
                    _agentTransform.rotation = Quaternion.Euler(0,0,0);
                }
            }
        }
    }

    public override void Sleep()
    {
        base.Sleep();
        _controller.GetComponent<Animator>().SetBool("isWalk", false);
    }

    public override void CheckConditions()
    {
        if (!_controller.CanChase())
        {
            _controller.SetIdle();
        }
        if (_controller.CanFlee())
        {
            _controller.SetFlee();
        }
        if (_controller.PuedeAtacar())
        {
            _controller.SetearAtaque();
        }
    }

    public Vector3 CalculateSteering()
    {
        // Direcci�n opuesta al target
        Vector3 fleeDir = (_agentTransform.position - _target.position.normalized);

        // Queremos ir a m�xima velocidad
        Vector3 direction = fleeDir * _maxSpeed;

        // C�lculo del steering
        Vector3 steer = direction;

        return steer;
    }
}
