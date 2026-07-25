using UnityEngine;

public class Hoguera : MonoBehaviour, IInteractable
{
    campfireFlicker fuelManager;
    [SerializeField]GameObject panel;
    public void Start()
    {
       
        fuelManager =GetComponent<campfireFlicker>();
    }
    void Update()
    {
        Player player = GeneralHandler.Instance.GetPlayer();
        if (Vector3.Distance(transform.position, player.transform.position)> 10f) panel.SetActive(false);
    }
    public string InteractMessage => $"<color=orange>Feed The Fire</color>";
    
    public void Interact()
    {
        //Player player = GeneralHandler.Instance.GetPlayer();
        //if(player.inventory.GetLogs() >= 1)
        //{
        //    fuelManager.AddFuel(30);
        //    player.inventory.RemoveLogs(1);
        //}
        if (panel.activeSelf == true) return;
        panel.SetActive(true);
        
    }

}
