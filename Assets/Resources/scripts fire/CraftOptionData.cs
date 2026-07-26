using Mono.Cecil;
using UnityEngine;
[System.Serializable] public struct ResourceCost
{
    public ResourceType type;
    public int amount;
}
[System.Serializable] public struct CraftOptionUI
{
    public CraftOptionData data;
    public GameObject availableUI;
    public GameObject lockedUI;
    public int requiredCampfireTier;
}
[CreateAssetMenu(fileName = "CraftOption", menuName = "Scriptable Objects/CraftOption")]
public class CraftOptionData : ScriptableObject
{
    public string optionName;
    public ResourceCost[] costs;
}
