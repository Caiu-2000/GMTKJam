using UnityEngine;

public class Player : Entity
{
    [SerializeField] private PlayerInput input;


    private void Start()
    {
        GeneralHandler.player = this;
        _combat.InitialiceThis(input);
    }


    public void ChangeWeapon(Tool newWeapon)
    {
        _combat.ChangeWeapon(newWeapon);
    }


}
