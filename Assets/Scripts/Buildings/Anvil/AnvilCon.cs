using UnityEngine;

public class AnvilCon : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject panelNo;

    public string InteractMessage =>"Build";

    public void Interact()
    {
        Player player = GeneralHandler.Instance.GetPlayer();
        if (panel.activeSelf == true) return;
        if(player.inventory.GetGold()>= 5) panel.SetActive(true);
        else panelNo.SetActive(true);
    }

    void Update()
    {
        Player player = GeneralHandler.Instance.GetPlayer();
        if (Vector3.Distance(transform.position, player.transform.position) > 10f)
        { 
            panel.SetActive(false);
            panelNo.SetActive(false);
        }
    }
}
