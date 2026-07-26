using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private State HalfLifeState;
    private bool FirsTimeBelowHalf = true;
    private void Start()
    {
        _ai = new AiComponnent(this);

        Machine.Initialice(this, _movement, _ai);
        _combat.InitialiceThis(Machine, this);
        SoundEmmiter.InitializeThis(this);
    }
    public override void applyDamage(float damage, Hitt attack)
    {
        base.applyDamage(damage, attack);
        if (_currentLife <= (_maxLife / 2) && FirsTimeBelowHalf)
        {
            FirsTimeBelowHalf = false;
            Machine.ForceInterrupt(HalfLifeState);
        }
        print(_currentLife + "  " + (_maxLife / 2));
    }
}
