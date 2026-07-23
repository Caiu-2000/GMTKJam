using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private StateMachine Machine;
    private AiComponnent _ai;

    private void Start()
    {
        _ai = new AiComponnent(this);
        
        Machine.Initialice(this, _movement , _ai);
    }
}
