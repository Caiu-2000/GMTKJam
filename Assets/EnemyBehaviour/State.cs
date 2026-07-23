using System;
using UnityEngine;

[System.Serializable]
public abstract class State
{

    [SerializeField] private string StateName;
    [SerializeField] private string AnimationTrigger;
    [SerializeField] private State DefaultNextState;
    private StateMachine ParentMachine;
    private Entity _controlledEntity;

    public void InitialiceState(StateMachine Machine , Entity entity)
    {
        ParentMachine = Machine;
        _controlledEntity = entity;
    }

    public virtual void StartState()
    {
        if (AnimationTrigger != null) _controlledEntity._animator.SetTrigger(AnimationTrigger);
    }

    public virtual void StopState() 
    {
    
    }

    public void UpdateState()
    {
       
    }
}
