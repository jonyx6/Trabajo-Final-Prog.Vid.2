using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgenteDelEstadoAtacar<T> : State<T>
{
    private Coroutine atacarCoroutine;
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
        atacarCoroutine = _controller.StartCoroutine(Atacar());
        Debug.Log("el personaje Orco Esta Atacando");

    }

    public override void Execute()
    {
       base.Execute();
    }

    public override void Sleep()
    {
        base.Sleep();
        _controller.StopCoroutine(atacarCoroutine);
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
    private IEnumerator Atacar()
    {
        while (true)
        {
            _controller.GetComponent<Animator>().SetTrigger("isAtacking");
            yield return new WaitForSeconds(1);
        }
    }

}
