using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StateMachine :MonoBehaviour
{
    [SerializeReference] private State[] statesList;
    [SerializeReference] private State CurrentState;
    [SerializeReference] private State DefaultState;
    [SerializeField] private State DeathState;
    
    private Entity _entity;
    public MovementComponent _movement;
    internal  AiComponnent _ai;

    public delegate void Attack( Vector3 ObjPos);
    public Attack OnAttack = delegate {  };


    [SerializeField] private TMPro.TextMeshPro DebugText;


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
            DebugText.text = CurrentState.StateName;
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
        if (CurrentState == DeathState) return;
        CurrentState.StopState();
        CurrentState = state;
        CurrentState.StartState();
        DebugText.text = state.StateName;

    }

    public void CharacterDied()
    {
        foreach (State state in statesList) { state.StopAllCoroutines(); }
        ChangeState(DeathState);
    }

    public void CallAttack(Vector3 ObjPos )
    {
        OnAttack?.Invoke(ObjPos);
    }

}
