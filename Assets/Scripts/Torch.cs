using System.Collections;
using UnityEngine;

public class Torch : MonoBehaviour
{
    IsPlayerOnTheLight lightManager;
    [SerializeField] Light torchLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnEnable()
    {
        lightManager = GeneralHandler.Instance.GetLightManager();
        lightManager.AddLight(torchLight);
        StartCoroutine(DeleteTorch());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DeleteTorch()
    {
        yield return new WaitForSeconds(30f);
        lightManager.RemoveLight(torchLight);
        gameObject.SetActive(false);
    }
}
