using System.Collections;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private State HalfLifeState;
    private bool FirsTimeBelowHalf = true;
    private bool FirstQuarter = true;
    [SerializeField] private BulletHellBehaviour HellBehaviour;

    [SerializeField] private Enemy[] Enemies;
    [SerializeField] float SpawnRadius = 10.0f;


    private void Start()
    {
        _ai = new AiComponnent(this);

        Machine.Initialice(this, _movement, _ai);
        _combat.InitialiceThis(Machine, this);
        SoundEmmiter.InitializeThis(this);
        SoundManager.instance.Play(SoundTypes.PlayingMusic);
    }
    public override void applyDamage(float damage, Hitt attack)
    {
        base.applyDamage(damage, attack);
        if (_currentLife <= (_maxLife * 0.25f) && FirstQuarter)
        {
            FirstQuarter = false;
            Machine.ForceInterrupt(HalfLifeState);
            HellBehaviour.Beguin();
        }
        if (_currentLife <= (_maxLife / 2) && FirsTimeBelowHalf)
        {
            StartCoroutine(SpawnEneies());
            FirsTimeBelowHalf = false;

        }

       
    }

    private IEnumerator SpawnEneies()
    {
        while (true)
        {
            Enemy enemigo = Instantiate(Enemies[Random.Range(0, 1)]);
            enemigo.transform.position = this.transform.position + new Vector3(Random.Range(-SpawnRadius , SpawnRadius) , 0 , Random.Range(-SpawnRadius, SpawnRadius)); 
            if (!FirstQuarter) break;
            yield return new WaitForSeconds(10.0f);
            if (!FirstQuarter) break;
        }
    }
}
