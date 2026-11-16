using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisponibilidadHabilidades : MonoBehaviour
{
    [SerializeField] private Image[] images;
    private Material[] materials;
    private Coroutine[] wipes;
    private static readonly int ProgressId = Shader.PropertyToID("_Progress");
    private void Awake()
    {
        materials = new Material[images.Length];
        wipes = new Coroutine[images.Length];
        for (int i = 0; i < images.Length; i++)
        {
            materials[i] = new Material(images[i].material);
            images[i].material = materials[i];
        }
    }

    private IEnumerator Start()
    {
        yield return null;
        GeneralHandler.Dash.OnCooldownStarted += d => StartWipe(0, d);
        GeneralHandler.Dash.OnReady += () => SetReady(0);
        GeneralHandler.DamageBuff.OnCooldownStarted += d => StartWipe(1, d);
        GeneralHandler.DamageBuff.OnReady += () => SetReady(1);
        GeneralHandler.Heatlbuff.OnCooldownStarted += d => StartWipe(2, d);
        GeneralHandler.Heatlbuff.OnReady += () => SetReady(2);
        SetProgress(0, GeneralHandler.Dash.CanDash ? 1f : 0f);
        SetProgress(1, GeneralHandler.DamageBuff.IsReady ? 1f : 0f);
        SetProgress(2, GeneralHandler.Heatlbuff.IsReady ? 1f : 0f);
    }
    private void StartWipe(int index, float duration)
    {
        if (wipes[index] != null) StopCoroutine(wipes[index]);
        wipes[index] = StartCoroutine(Wipe(index, duration));
    }
    private IEnumerator Wipe(int index, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            SetProgress(index, elapsed / duration);
            yield return null;
        }
    }
    private void SetReady(int index)
    {
        if (wipes[index] != null) StopCoroutine(wipes[index]);
        SetProgress(index, 1f);
    }
    private void SetProgress(int index, float value)
    {
        materials[index].SetFloat(ProgressId, Mathf.Clamp01(value));
    }
}