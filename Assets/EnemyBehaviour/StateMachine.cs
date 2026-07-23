using System;
using UnityEngine;

public class StateMachine :MonoBehaviour
{
    [SerializeReference] private State[] statesList;
    [SerializeReference] private State CurrentState;
    [SerializeReference] private State DefaultState;


    private Entity _entity;
    public MovementComponent _movement;
    internal  AiComponnent _ai;

    internal void Initialice(Enemy enemy, MovementComponent movement , AiComponnent AI)
    {
        _entity = enemy;
        _movement = movement;
        _ai = AI;

        foreach (State state in statesList)
        {
            state.InitialiceState(this, _entity);
        }

        if (DefaultState != null)
        {
            CurrentState = DefaultState;
            CurrentState.StartState();
        }
    }
    void Update()
    {
        CurrentState.UpdateState();    
    }
    public void ForceInterrupt(State obligatoryState)
    {
        
    }
    public void ChangeState(State state) 
    {
        CurrentState.StopState();
        CurrentState = state;
        CurrentState.StartState();

    }

}
