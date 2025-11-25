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
        if (!_controller.PuedeAtacar())
        {
            if (_controller.CanChase())
                _controller.SetChase();
            else
                _controller.SetIdle();
        }
        else if (_controller.CanFlee())
        {
            _controller.SetFlee();
        }
    }

    private IEnumerator Atacar()
    {
        while (_controller.PuedeAtacar())
        {
            _controller.GetComponent<Animator>().SetTrigger("isAtacking");
            yield return new WaitForSeconds(1);
        }
    }


}
