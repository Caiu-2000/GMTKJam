using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State[] statesList;
    [SerializeField] private State CurrentState;
    [SerializeField] private State DefaultState;


    private Entity _entity;
    private MovementComponent _movement;
    private AiComponnent _ai;

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
