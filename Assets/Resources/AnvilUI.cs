using UnityEngine;
using UnityEngine.InputSystem;

public class AnvilUI : MonoBehaviour
{
    Player player;
    int nextWeapon = 0;
    int maxWeapon = 3;
    bool resourcesCheck = false;
    [SerializeField]Tool[] weapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)player = GeneralHandler.Instance.GetPlayer();
        resourcesCheck = CheckResources(nextWeapon);
        if (Keyboard.current.tKey.wasPressedThisFrame && nextWeapon <maxWeapon && resourcesCheck)
        { 
            player.ChangeWeapon(weapon[nextWeapon]);
            nextWeapon++;
            gameObject.SetActive(false);
            if (nextWeapon == 1)
                player.inventory.RemoveGold(10);
            else if (nextWeapon == 2)
            {
                player.inventory.RemoveGold(15);
                player.inventory.RemoveLootEspectro(5);
            }
            else if (nextWeapon == 3)
            {
                player.inventory.RemoveGold(25);
                player.inventory.RemoveLootEspectro(10);
            }
            resourcesCheck = false;
        }
    }
    bool CheckResources(int level)
    {
        if (level == 0)
        {
            if (player.inventory.GetGold() >= 10) return true;
            else return false;
        }
        else if (level == 1)
        {
            if (player.inventory.GetGold() >= 15 && player.inventory.GetLootEspectro() >= 5) return true;
            else return false;
        }
        else if (level == 2)
        {
            if (player.inventory.GetGold() >= 25 && player.inventory.GetLootEspectro() >= 10) return true;
            else return false;
        }
        return false;
    }

}
