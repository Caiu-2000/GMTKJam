
using UnityEngine;

//[System.Serializable]
public  class State : MonoBehaviour
{

    [SerializeField] public string StateName;
    [SerializeField] protected string AnimationTrigger;
    [SerializeField] protected State DefaultNextState;
    protected StateMachine ParentMachine;
    protected Entity _controlledEntity;

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

    public virtual void UpdateState()
    {
       
    }
}
