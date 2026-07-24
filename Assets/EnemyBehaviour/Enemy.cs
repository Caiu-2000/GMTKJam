using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private StateMachine Machine;
    private AiComponnent _ai;
    
    private void Start()
    {
        _ai = new AiComponnent(this);
        
        Machine.Initialice(this, _movement , _ai);
        _combat.InitialiceThis(Machine);
        
    }


    public void HitConnectded(Player coll)
    {

    }

    public override void Die()
    {
        Machine.CharacterDied();
    }


}
