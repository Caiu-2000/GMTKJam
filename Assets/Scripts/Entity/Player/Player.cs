using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [SerializeField] public PlayerInput input;
    public Inventory inventory;
    public float PlayerSpeed;
    [SerializeField] Material damageMaterial;
    [SerializeField] string intensityReference = "_Intensity";
    [SerializeField] float damageDebugToTake = 5f;
    private int intensityId;
    private void Start()
    {
        GeneralHandler.player = this;
        _combat.InitialiceThis(input);
        SoundEmmiter.InitializeThis(this);
        inventory = new Inventory();
        intensityId = Shader.PropertyToID(intensityReference);
 
    }

    public void Update()
    {
        _movement.Speed = PlayerSpeed;
        damageMaterial.SetFloat(intensityId, CheckLife());
        if(Keyboard.current.numpad9Key.wasPressedThisFrame)
        {
            _currentLife -= damageDebugToTake;
        }
        if (Keyboard.current.numpadPlusKey.wasPressedThisFrame)
        {
            _currentLife += damageDebugToTake;
        }
    }
    public void ChangeWeapon(Tool newWeapon)
    {
        _combat.ChangeWeapon(newWeapon);
    }

    public override void Die(bool noReward = false)
    {
        GM.PlayerDied();
    }
    float CheckLife()
    {
        return 1f - Mathf.Clamp01(_currentLife / _maxLife);
    }
}
