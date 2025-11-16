
using UnityEngine;

public class FSM<T>
{
    State<T> _estadoActual;

    public State<T> EstadoActual { get => _estadoActual; set => _estadoActual = value; }

    public FSM()
    {

    }

    public FSM(State<T> initState)
    {
        SetInit(initState);
    }

    public State<T> GetCurrentState()
    {
        return _estadoActual;
    }

    public void SetInit(State<T> init)
    {
        if (init == null)// si no existe un estado inicial
        {
            Debug.LogError("[FSM] Estado inicial es NULL. No se puede iniciar la FSM.");
            return;
        }

        _estadoActual = init;
        Debug.Log("[FMS] ESTADO INICIAL ESTABLECIDO: " + _estadoActual.GetType().Name);
        _estadoActual.Enter();
    }

    public void OnUpdate()
    {
        if (_estadoActual == null)
        {
            Debug.LogError("[FSM] _current es NULL en OnUpdate. Verifica que SetInit() haya sido llamado.");
            return;
        }


        _estadoActual.Execute();


    }

    public void ChangeState(T input)
    {
        State<T> newState = _estadoActual.GetTransition(input);
        if (newState == null)
        {
            Debug.LogWarning("No se encontró una transición válida para el estado " + _estadoActual);
            return;  // No cambiar de estado si no hay transición
        }

        _estadoActual.Sleep();
        _estadoActual = newState;
        _estadoActual.Enter();
    }

}
    
