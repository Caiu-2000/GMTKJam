using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Scriptable Objects/Tools")]
[System.Serializable]
public class ToolObject : ScriptableObject
{
    [SerializeField] public Tool tool;
}
