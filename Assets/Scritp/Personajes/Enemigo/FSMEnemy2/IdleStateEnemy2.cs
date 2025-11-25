using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateEnemy2<T> :State<T>
{
    private FSMEnemy2 _controller;

    public IdleStateEnemy2(T stateID,Transform NPCAgent,FSMEnemy2 controller,FSM<T> fsm):base(stateID,NPCAgent,fsm)
    {
        _agentTransform = NPCAgent;
        _fsm = fsm;
        _controller = controller;
    }

    public override void Enter()
    {
        //base.Enter();
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void CheckConditions()
    {
        if (_controller.CanChase())
        {
            _controller.SetearAtaque();
        }
    }

    public override void Sleep()
    {
        base.Sleep();
    }
}
