using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState<T>:State<T>
{
    private Boss_Fms_Controller _controller;




    public BossIdleState(T stateID, Transform NPCAgent, Boss_Fms_Controller controller, FSM<T> fsm) : base(stateID, NPCAgent, fsm)
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
            _controller.SetChase();
        }

    }

    public override void Sleep()
    {
        base.Sleep();

    }
}
