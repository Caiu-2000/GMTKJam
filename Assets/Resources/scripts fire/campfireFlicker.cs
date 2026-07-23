using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class campfireFlicker : MonoBehaviour
{
    [SerializeField] Light flameLight;
    [SerializeField] float baseIntensity = 3f;
    [SerializeField] float intensityVariance = 1f;
    [SerializeField] float noiseSpeed = 1f;
    Coroutine dimLightRoutine;
    float seed;

    void Awake() => seed = Random.value*100f;
    private void Start()
    {
        dimLightRoutine = StartCoroutine(DimLight(baseIntensity, 0f, 60f));
    }
    void Update()
    {
        float noise = Mathf.PerlinNoise(seed, Time.time * noiseSpeed);
        flameLight.intensity = baseIntensity + (noise - 0.5f) * 2f * intensityVariance;
        if (baseIntensity <= 0) flameLight.enabled = false;
        if (Keyboard.current.numpad1Key.wasPressedThisFrame) AddFuel(3);
        if (Keyboard.current.numpad2Key.wasPressedThisFrame) RemoveFuel(1);
    }

    IEnumerator DimLight(float startValue, float endValue, float duration)
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            baseIntensity = Mathf.Lerp(startValue, endValue, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        baseIntensity = endValue;
    }
    public void AddFuel(float amout)
    {
        Debug.Log("Se añadio combustible");
        if(dimLightRoutine != null) StopCoroutine(dimLightRoutine);
        baseIntensity += amout;
        float newTime = baseIntensity * 0.6f; //Como el base de 100 toma 1 minuto (60 seg) en apagarse base 1 toma 0.6 seg
        if(flameLight.enabled == false) flameLight.enabled = true;
        dimLightRoutine = StartCoroutine(DimLight(baseIntensity, 0f, newTime));
    }
    public void RemoveFuel(float amout)
    {
        Debug.Log("Se saco combustible");
        StopCoroutine(dimLightRoutine);
        baseIntensity -= amout;
        float newTime = baseIntensity * 0.6f;
        dimLightRoutine = StartCoroutine(DimLight(baseIntensity, 0f, newTime));
    }    
}
