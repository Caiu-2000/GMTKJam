using UnityEngine;

public class Player : Entity
{
    [SerializeField] private PlayerInput input;
    public Inventory inventory;

    private void Start()
    {
        GeneralHandler.player = this;
        _combat.InitialiceThis(input);
        inventory = new Inventory();
    }

}
