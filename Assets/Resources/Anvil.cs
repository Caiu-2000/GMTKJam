using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Anvil : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject panel;
    [SerializeField] CraftOptionUI[] upgradeLevels;
    int currentLevel = 0;
    public string InteractMessage => "Improve your axe";

    public void Interact()
    {
        if (panel.activeSelf == true) return;
        panel.SetActive(true);
        RefreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        Player player = GeneralHandler.Instance.GetPlayer();
        if (Vector3.Distance(transform.position, player.transform.position) > 10f) panel.SetActive(false);
    }
    public void RefreshUI()
    {
        int campfireTier = GeneralHandler.Campfire != null ? GeneralHandler.Campfire.currentTier : 0;

        for (int i = 0; i < upgradeLevels.Length; i++)
        {
            bool isCurrent = i == currentLevel;
            bool meetsFireRequirement = campfireTier >= upgradeLevels[i].requiredCampfireTier;
            bool canAfford = isCurrent && meetsFireRequirement && CraftUtility.CanAfford(upgradeLevels[i].data);

            upgradeLevels[i].availableUI.SetActive(canAfford);
            upgradeLevels[i].lockedUI.SetActive(isCurrent && !canAfford);
        }
    }

    public void OnUpgradeSuccess()
    {
        currentLevel++;
        RefreshUI();
    }
}
