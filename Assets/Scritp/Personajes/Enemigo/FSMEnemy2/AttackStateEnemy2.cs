using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateEnemy2<T>:State<T>
{
    private Coroutine _atacarCoroutine;
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
        _atacarCoroutine = _controller.StartCoroutine(Atacar());
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Sleep()
    {
        if (_atacarCoroutine != null)
        {
            _controller.StopCoroutine(_atacarCoroutine);
            _atacarCoroutine = null;
        }
    }

    public override void CheckConditions()
    {
        if (_controller.siElEnemigoEstaSerca())
        {
            _controller.SetFlee();
        }

        if (!_controller.CanChase())
        {
            _controller.SetIdle();
        }

    }

    private IEnumerator Atacar()
    {
        while (_controller.CanChase())
        {
            _controller.GetComponent<Animator>().SetTrigger("isAtacking");
            _controller.GetComponent<ShooterSystem>().DispararAObjetivo( _controller._target.position);
            yield return new WaitForSeconds(1);
        }
    }


}
