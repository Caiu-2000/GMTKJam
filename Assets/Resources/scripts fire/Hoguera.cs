using UnityEngine;

public class Hoguera : MonoBehaviour, IInteractable
{
    campfireFlicker fuelManager;
    public void Start()
    {
        fuelManager =GetComponent<campfireFlicker>();
    }
    public string InteractMessage => $"<color=orange>Feed The Fire</color>";

    public void Interact()
    {
        Player player = GeneralHandler.Instance.GetPlayer();
        if(player.inventory.GetLogs() >= 1)
        {
            fuelManager.AddFuel(30);
            player.inventory.RemoveLogs(1);
        }
        
        
    }

}
