using UnityEngine;
using UnityEngine.InputSystem;

public class AnvilUI : MonoBehaviour
{
    Player player;
    int nextWeapon = 0;
    int maxWeapon = 2;
    [SerializeField]Tool[] weapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)player = GeneralHandler.Instance.GetPlayer();
        if (Keyboard.current.tKey.wasPressedThisFrame && nextWeapon <maxWeapon)
        { 
            player.ChangeWeapon(weapon[nextWeapon]); 
            gameObject.SetActive(false);
        }
    }
}
