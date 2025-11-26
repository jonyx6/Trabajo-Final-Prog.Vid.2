using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState<T>: State<T>
{
    private Coroutine atacarCoroutine;
    private Boss_Fms_Controller _controller;

    public BossAttackState(T stateID, Transform NPCAgent, Boss_Fms_Controller controller, FSM<T> fsm) : base(stateID, NPCAgent, fsm)
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

        if (!_controller.PuedeAtacar() && !_controller.CanChase())
        {
            _controller.SetIdle();
        }
        if (_controller.CanFlee())
        {
            _controller.SetFlee();
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
