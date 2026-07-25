using UnityEngine;




public class Enemy : Entity
{
    [SerializeField] private StateMachine Machine;
    private AiComponnent _ai;
    [SerializeField] private enemyLoot Loot;
    private void Start()
    {
        _ai = new AiComponnent(this);
        
        Machine.Initialice(this, _movement , _ai);
        _combat.InitialiceThis(Machine , this);
        SoundEmmiter.InitializeThis(this);
    }


    public void HitConnectded(Player coll)
    {

    }

    public override void Die()
    {
        GiveLoot();
        Machine.CharacterDied();
    }



    public void GiveLoot()
    {
        if (Loot == enemyLoot.GASPARIN)
        {
            GeneralHandler.player.inventory.AddLootEspectro(1);
        }
        else if (Loot == enemyLoot.OJO)
        {
            GeneralHandler.player.inventory.AddLootOjo(1);
        }
    }
}
