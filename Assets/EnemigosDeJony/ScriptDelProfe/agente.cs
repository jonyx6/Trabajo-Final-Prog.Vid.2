using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgenteDelEstadoAtacar<T> : State<T>
{
    private Agent_FSM_Controller _controller;

    public AgenteDelEstadoAtacar(T stateID, Transform NPCAgent, Agent_FSM_Controller controller, FSM<T> fsm) : base(stateID, NPCAgent, fsm)
    {
        _agentTransform = NPCAgent;
        _fsm = fsm;
        _controller = controller;

    }
    public override void Enter()
    {
        base.Enter();
        _controller.GetComponent<Animator>().SetTrigger("isAtacking");
        Debug.Log("el personaje Orco Esta Atacando");

    }

    public override void Execute()
    {
       

    }

    public override void CheckConditions()
    {

        
        if (!_controller.PuedeAtacar())
        {
            _controller.SetChase();
        }

        if(!_controller.PuedeAtacar() && !_controller.CanChase())
        {
            _controller.SetIdle();
        }

    


    }


    public override void Sleep()
    {
        //base.Sleep();
        _controller.GetComponent<Animator>().SetBool("isAtacking", false);
    }

}
