
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public abstract class Entity : MonoBehaviour, IHittable
{

    [SerializeField] protected float _currentLife = 0, _maxLife = 100;

    public bool _damCD = false;
    public bool _CanInputMovement = true;

    public float _maxStamina = 100.0f, _currentStamina = 0.0f;
    public float _StaminaCD = 1f, _StaminaCount = 0, _StaminaRegen = 25f;

    [SerializeField] public MovementComponent _movement;
    [SerializeField] protected CombatComponnetnt _combat;
    [HideInInspector]public Animator _animator;
    [SerializeField] public Animator _SpriteAnimator;
    private AiComponnent _aiComponnent;

    [SerializeField]
    protected EntitySoundComponent SoundEmmiter = new EntitySoundComponent();



    #region Delegates

    public delegate void HealthChange(float NewHealth, float MaxHealth);
    public HealthChange OnHealthChanged = delegate { };

    public delegate void Damaged(Hitt attak);
    public Damaged OnDamaged = delegate { };

    public delegate void Dead();
    public delegate void Attack();

    public Dead OnEntityDead = delegate { };
    public Attack OnEntityAttacked = delegate { };

    #endregion
    
    private void Awake()
    {
        _currentLife = _maxLife;
        _currentStamina = _maxStamina;
        _animator = GetComponent<Animator>();

    }



    public virtual void applyDamage(float damage , Hitt attack)
    {
        if (_damCD)
        {
            print("Se intento golpear pero estaba en cd");
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

    private void Update()
    {
        if (_StaminaCount > 0)
        {
            _StaminaCount -= Time.deltaTime;
        }
        else if (_currentStamina < _maxStamina)
        {
            _currentStamina += _StaminaRegen * Time.deltaTime;
            if (_currentStamina > _maxStamina) _currentStamina = _maxStamina;
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }


    public virtual void ReduceStamina(float Cost)
    {
        _currentStamina -= Cost;
        if (_currentStamina < 0) _currentStamina = 0;
    }

    public virtual void Heal(float _healAmount)
    {
        _currentLife += _healAmount;
        if (_currentLife > _maxLife) _currentLife = _maxLife;
        OnHealthChanged?.Invoke(_currentLife , _maxLife);
    }


    public void Hitt(Hitt hitt)
    {
      
        applyDamage(hitt.HittDamage , hitt );
    }



    protected IEnumerator DamCd()
    {
        _damCD = true;
        yield return new WaitForSeconds(0.1f);
        _damCD = false;
    }



}