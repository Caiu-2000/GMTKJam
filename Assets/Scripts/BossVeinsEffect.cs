using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BossVeinsEffect : MonoBehaviour
{
    [SerializeField] private ScriptableRendererData rendererData;
    [SerializeField] private string featureName = "BossVeins";
    private ScriptableRendererFeature feature;
    private void Awake()
    {
        foreach (var f in rendererData.rendererFeatures)
        {
            if (f != null && f.name == featureName)
            {
                feature = f;
                break;
            }
        }
        if (feature == null)
        {
            Debug.LogWarning($"Renderer feature '{featureName}' not found");
            return;
        }
        feature.SetActive(false);
    }
    public void Show() { if (feature != null) feature.SetActive(true); }
    public void Hide() { if (feature != null) feature.SetActive(false); }
    private void OnDisable() { if (feature != null) feature.SetActive(false); }
}