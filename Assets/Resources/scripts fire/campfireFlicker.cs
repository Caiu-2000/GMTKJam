using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class campfireFlicker : MonoBehaviour
{
    [SerializeField] Light flameLight;
    [SerializeField] float baseIntensity = 3f;
    [SerializeField] float intensityVariance = 1f;
    [SerializeField] float noiseSpeed = 1f;
    [SerializeField] CampfireUpgradeData upgradeData;
    Coroutine dimLightRoutine;
    float seed;
    public int currentTier = 0;
    [SerializeField]GameObject[] campfireModels;
    float intensityMultiplier = 1f;
    public float MaxFuel = 150;

    public delegate void FuelChanged(float currentValue , float MaxValue);

    public FuelChanged OnFuelChanged;


    void Awake() => seed = Random.value*100f;
    private void Start()
    {
        dimLightRoutine = StartCoroutine(DimLight(baseIntensity, 0f, 60f));
        GeneralHandler.Campfire = this;
        ApplyTier(currentTier);
    }
    void Update()
    {
        float noise = Mathf.PerlinNoise(seed, Time.time * noiseSpeed);
        flameLight.intensity = baseIntensity * intensityMultiplier;//(baseIntensity + (noise - 0.5f) * 2f * intensityVariance)*intensityMultiplier;
        if (baseIntensity <= 0) flameLight.enabled = false;
        if (Keyboard.current.numpad1Key.wasPressedThisFrame) AddFuel(3);
        if (Keyboard.current.numpad2Key.wasPressedThisFrame) RemoveFuel(1);
    }

    public void Upgrade()
    {
        if (currentTier > upgradeData.maxTier) return;
        if (currentTier == 2) return;
        campfireModels[currentTier].SetActive(false);
        currentTier++;
        campfireModels[currentTier].SetActive(true);
        ApplyTier(currentTier);
    }

    void ApplyTier(int tier)
    {
        float t = (float)tier / upgradeData.maxTier;
        flameLight.range = upgradeData.rangeCurve.Evaluate(t);
        intensityMultiplier = upgradeData.intensityCurve.Evaluate(t);
    }
    IEnumerator DimLight(float startValue, float endValue, float duration)
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            baseIntensity = Mathf.Lerp(startValue, endValue, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            OnFuelChanged?.Invoke(baseIntensity, MaxFuel);
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
  
        StopCoroutine(dimLightRoutine);
        baseIntensity -= amout;
        float newTime = baseIntensity * 0.6f;
        dimLightRoutine = StartCoroutine(DimLight(baseIntensity, 0f, newTime));
    }    
}
