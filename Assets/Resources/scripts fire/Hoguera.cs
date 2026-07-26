using UnityEngine;

public class Hoguera : MonoBehaviour, IInteractable
{
    campfireFlicker fuelManager;
    [SerializeField]GameObject panel;
    [SerializeField] CraftOptionUI feedOption;
    [SerializeField] CraftOptionUI torchOption;
    [SerializeField] CraftOptionUI[] upgradeLevels;
    Player player;
    public void Start()
    {
       
        fuelManager =GetComponent<campfireFlicker>();
    }
    void Update()
    {
        player = GeneralHandler.Instance.GetPlayer();
        if (Vector3.Distance(transform.position, player.transform.position)> 10f) panel.SetActive(false);
    }
    public string InteractMessage => $"<color=orange>Feed The Fire</color>";
    
    public void Interact()
    {
        if (panel.activeSelf == true) return;
        panel.SetActive(true);
        RefreshUI();
    }
    public void RefreshUI()
    {
        RefreshSingle(feedOption);
        RefreshSingle(torchOption);

        for (int i = 0; i < upgradeLevels.Length; i++)
        {
            bool isCurrent = i == fuelManager.currentTier;
            bool canAfford = isCurrent && CraftUtility.CanAfford(upgradeLevels[i].data);
            upgradeLevels[i].availableUI.SetActive(canAfford);
            upgradeLevels[i].lockedUI.SetActive(isCurrent && !canAfford);
        }
    }
    void RefreshSingle(CraftOptionUI option)
    {
        bool canAfford = CraftUtility.CanAfford(option.data);
        option.availableUI.SetActive(canAfford);
        option.lockedUI.SetActive(!canAfford);
    }

}
