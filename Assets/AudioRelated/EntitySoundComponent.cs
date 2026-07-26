
using UnityEngine;

[System.Serializable]
public class EntitySoundComponent : SoundEmitterComponent
{
    protected Entity parentEntity;
    private bool IsEnemy = true;

    public override void InitializeThis(Entity ParentEntity= null)
    {
        ParentEntity.OnEntityAttacked += PlayAttack;
        ParentEntity.OnEntityDead += PlayDeath;
        ParentEntity.OnDamaged += PlayDamaged;
        if (ParentEntity is Player) IsEnemy = false;
        base.InitializeThis(ParentEntity);
        
        
    }

    public void PlayDamaged(Hitt data)
    {
     
        PlaySound(SoundTypes.Damaged , true);
    }
    public void PlayDeath()
    {
        PlaySound(SoundTypes.Death);
    }
    public void PlayAttack()
    {
        PlaySound(SoundTypes.Hit);
    }
}
