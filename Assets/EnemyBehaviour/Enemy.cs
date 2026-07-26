using UnityEngine;




public class Enemy : Entity
{
    [SerializeField] protected StateMachine Machine;
    protected AiComponnent _ai;
    [SerializeField] protected enemyLoot Loot;
    [SerializeField] private int GoldLooteable = 1;
    
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

    public override void Die(bool noReward = false)
    {
        if(noReward == false)GiveLoot();
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
        GeneralHandler.player.inventory.AddGold(GoldLooteable);
    }
    public override void applyDamage(float damage, Hitt attack)
    {
        if (GeneralHandler.DamageBuffed)
        {
           
            damage = damage * 2;

        }
        if (_damCD)
        {
       
            return;
        }
        StartCoroutine(DamCd());
        if (_currentLife == 0) _currentLife = _maxLife;
        _currentLife -= damage;
        OnDamaged?.Invoke(attack);
        OnHealthChanged?.Invoke(_currentLife, _maxLife);
        if (_currentLife <= 0)
        {
            Die();
        }


    }
}



