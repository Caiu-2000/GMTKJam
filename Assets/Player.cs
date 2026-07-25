using UnityEngine;

public class Player : Entity
{
    [SerializeField] public PlayerInput input;
    public Inventory inventory;
    public float PlayerSpeed;
    private void Start()
    {
        GeneralHandler.player = this;
        _combat.InitialiceThis(input);
        SoundEmmiter.InitializeThis(this);
        inventory = new Inventory();
 
        print(_movement.Speed);
    }

    public void Update()
    {
        _movement.Speed = PlayerSpeed;
    }
    public void ChangeWeapon(Tool newWeapon)
    {
        _combat.ChangeWeapon(newWeapon);
    }

    public override void Die()
    {
        GM.PlayerDied();
    }

}
