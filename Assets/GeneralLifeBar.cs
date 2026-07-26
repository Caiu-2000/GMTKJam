using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GeneralLifeBar : MonoBehaviour
{
    [SerializeField] Entity ParentEntity;
    [SerializeField] Image Image;
    private float LastHealtValure = 1;
    private void Start()
    {
        ParentEntity.OnHealthChanged += UpdateLife;
    }


    public void UpdateLife(float current, float max)
    {

        StopCoroutine(ChangeUILife(current, max));
      
        StartCoroutine(ChangeUILife(current, max));



    }
    private IEnumerator ChangeUILife(float curr, float max)
    {
        float ElapsedTime = 0.0f;

        float percentValue = curr / max;
        while ((ElapsedTime) < 1)
        {
            ElapsedTime += Time.deltaTime * 2;
            LastHealtValure = Mathf.Lerp(LastHealtValure, percentValue, ElapsedTime);
            Image.fillAmount = (LastHealtValure);
            yield return null;
        }

        yield return null;
    }
}
