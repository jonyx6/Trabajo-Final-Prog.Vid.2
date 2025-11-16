using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class State<T>// T==generico == PUEDE RECIBIR CUALQUIER TIPO DE DATO
{
    // dicionario : T== la key Y State<T> == EL VALOR DEL ESTADO ;
    Dictionary<T, State<T>> _transitions = new Dictionary<T, State<T>>(); // creamos una instancia de un diccionario

    protected Transform _agentTransform; // referencia al objeto (posición, rotación, escala).

    protected FSM<T> _fsm; // guardamos al referencia ala maquina de estados en una variable

    public T StateID { get; private set; }// T== es el tipo genérico que representa el identificador del estado ( el enum AgentAIStates).


    /* Analogía
     Imaginá que cada estado es un actor en una obra de teatro:

     protected Transform _agentTransform → es el escenario donde actúa(posición, rotación).

     protected FSM<T> _fsm → es el director de la obra, que decide cuándo cambiar de actor.

     public T StateID { get; private set; } → es el nombre del papel que ese actor está interpretando(Idle, Chase, Flee).
    */

    public State(T stateID, Transform NPCAgent, FSM<T> fsm)
    {
        StateID = stateID;
        _agentTransform = NPCAgent;
        _fsm = fsm;
    }

    /*
     Analogía
    Imaginá que estás contratando un actor para una obra de teatro:

    El constructor es la entrevista inicial.

    Le das:

    El mapa de transiciones (qué escenas puede pasar después).

    El escenario donde va a actuar (Transform).

    El director que lo controla (FSM).

    El nombre del papel que va a interpretar (StateID).

    Con esa información, el actor ya está listo para actuar en la obra.
     */


    public virtual void Enter()
    {
        Debug.Log("Enter State: " + this.GetType().Name);
    }
    public virtual void Execute()
    {
            CheckConditions();
           //Debug.Log("Executing State: " + this.GetType().Name);
    }

    public virtual void Sleep()
    {
        Debug.Log("Sleep State: " + this.GetType().Name);
    }

    public virtual void CheckConditions()
    {

    }/*
      
      Analogía
        Imaginá que cada estado es un actor en una obra de teatro:

        Enter() → el actor entra al escenario.

        Execute() → el actor actúa su papel mientras está en escena.

        CheckConditions() → el actor evalúa si debe salir o cambiar de escena.

        Sleep() → el actor se retira del escenario y se prepara para el próximo papel.
      
      
      */


    public void AddTransition(T input, State<T> state) 
    {

        /*Qué hace: agrega una transición al diccionario _transitions.

        Clave (input) → el identificador del estado al que querés ir (ejemplo: AgentAIStates.Chase).

        Valor (state) → la instancia del estado destino (ejemplo: AgentChaseState). 👉 Con esto decís: “desde este estado, si recibo el input X, puedo ir al estado Y”.*/

        _transitions[input] = state; 
    }

    public void RemoveTransition(T input)
    {
       // Qué hace: elimina una transición del diccionario si existe. 👉 Sirve para limpiar o modificar dinámicamente las rutas posibles desde este estado.

        if (_transitions.ContainsKey(input))
            _transitions.Remove(input);
    }


    public State<T> GetTransition(T input)
    {
        /*
         Qué hace: busca en el diccionario si existe una transición para el input dado.

        Si existe → devuelve el estado destino.

        Si no existe → muestra un warning y devuelve null. 👉 Es el método que usa la FSM cuando llamás a ChangeState(input) para saber a qué estado debe saltar.
         */


        if (_transitions.ContainsKey(input))
        {
            return _transitions[input];
        }
        else
        {
            Debug.LogWarning($"[FSM] No existe transición hacia {input}");
            return null;
        }

    }

    /*Analogía
        Imaginá que cada estado es una estación de tren:

        AddTransition → agrega una vía nueva hacia otra estación.

          RemoveTransition → cierra una vía que ya no se usa.

            GetTransition → consulta el mapa: “si quiero ir a Chase desde Idle, ¿hay una vía disponible?”.
     
     */








}
