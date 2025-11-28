using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChaseState<T> : State<T>
{

    private float _maxSpeed;
    private float _chaseSpeed;
    private float _rotationSpeed;
    private InSightViewPro _inSightViewPro;
    private Boss_Fms_Controller _controller;

    public BossChaseState(T stateID, Transform NPCAgent, Boss_Fms_Controller controller, FSM<T> fsm, InSightViewPro inSightViewPro, float maxSpeed, float rotSpeed)
   : base(stateID, NPCAgent, fsm)
    {
        _inSightViewPro = inSightViewPro;
        _maxSpeed = maxSpeed;
        _rotationSpeed = rotSpeed;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();// ejecuta la funcion del la clase base  del state

        _chaseSpeed = _maxSpeed;
        _controller.GetComponent<Animator>().SetBool("Walk", true);
    }

    public override void Execute()
    {
        base.Execute();
        Debug.Log(_inSightViewPro.objetivoActual);
        if (_inSightViewPro.objetivoActual != null)
        {
            Vector3 direction = (_inSightViewPro.objetivoActual.position - _agentTransform.position).normalized;
            _agentTransform.position += direction * _chaseSpeed * Time.deltaTime;

            //RotarHacia(_inSightViewPro.objetivoActual);
            // Creamos la variable que apunta en la direcci�n de movimiento
            Vector3 dir = new Vector3(direction.x, direction.y, 0).normalized;

            // Creamos la rotaci�n objetivo
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.right, dir);

            // Rotaci�n suave
            _agentTransform.rotation = Quaternion.RotateTowards(_agentTransform.rotation, targetRotation, _rotationSpeed);

/*             Vector3 rotacion = _agentTransform.rotation.eulerAngles;
            // Volteamos el sprite segun la direccion en X
            if (direction.x < 0)
            {
                rotacion.y = -180;
                //rotacion.z = -rotacion.z;
            }
            else
            {
                rotacion.y = 0;
            }
            _agentTransform.eulerAngles = rotacion; */

        }
    }

    public override void Sleep()
    {
        base.Sleep();
        _controller.GetComponent<Animator>().SetBool("Walk", false);
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
        // Direcci?n opuesta al target
        Vector3 chaseDir = (_inSightViewPro.objetivoActual.position - _agentTransform.position).normalized;

        // Queremos ir a m?xima velocidad
        Vector3 direction = chaseDir * _maxSpeed;

        // C?lculo del steering
        Vector3 steer = direction;

        return steer;
    }
    public void RotarHacia(Transform objective)
    {
        Vector3 dir = objective.position - _agentTransform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //_agentTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector3 rotacion = _agentTransform.rotation.eulerAngles;
        rotacion.z += Mathf.Clamp(angle / 199, -1, 1);
        _agentTransform.eulerAngles = rotacion;
    }




}
