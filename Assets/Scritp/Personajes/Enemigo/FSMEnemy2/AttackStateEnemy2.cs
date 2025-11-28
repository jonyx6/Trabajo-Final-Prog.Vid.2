using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class AttackStateEnemy2<T>:State<T>
{
    private Coroutine atacarCoroutine;
    private FSMEnemy2 _controller;

    public AttackStateEnemy2(T stateID, Transform NPCAgent, FSMEnemy2 controller , FSM<T> fsm) : base( stateID ,NPCAgent,fsm)
    {
        _agentTransform = NPCAgent;
        _controller = controller;
        _fsm = fsm;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.GetComponent<ShooterSystem>().objetivo = _controller._target;
        atacarCoroutine = _controller.StartCoroutine(Atacar());
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


    private IEnumerator Atacar()
    {
        while (true)
        {
            _controller.GetComponent<Animator>().SetTrigger("isAtacking");
            yield return new WaitForSeconds(4);
        }
    }

    public override void CheckConditions()
    {
        if (!_controller.CanChase())
        {
            _controller.SetIdle();
        }

        if (_controller.siElEnemigoEstaSerca())
        {
            _controller.SetFlee();
        }
    }


}
