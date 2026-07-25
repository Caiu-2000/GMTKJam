
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
    
    private Player _player;
    [SerializeField] private Image _lifeBar;

    private float LastHealtValure = 1;

    [SerializeField] private Image ParryIndicator;



    private void Update()
    {
        if (_player == null) CheckForPlayer();
    }

    private void CheckForPlayer()
    {
        print("Estoy buscando al player");
        GeneralHandler.UiHandler= this;

        _player = GeneralHandler.player;

        if (GeneralHandler.player)
        {
            GeneralHandler.player.OnHealthChanged += UpdateLife;
            
        }

    }

    public void UpdateLife(float current, float max)
    {

        StopCoroutine(ChangeUILife(current , max));
        print("Se llamo a actualizar vida" + max + current);
        StartCoroutine(ChangeUILife(current, max));



    }
    public void UpdateFireProgress(float current , float max)
    {

    }


    private IEnumerator ChangeUILife(float curr, float max)
    {
        float ElapsedTime = 0.0f;

        float percentValue = curr / max;
        while ((ElapsedTime) < 1)
        {
            ElapsedTime += Time.deltaTime * 2;
            LastHealtValure = Mathf.Lerp(LastHealtValure, percentValue, ElapsedTime);
            _lifeBar.fillAmount = (LastHealtValure);
            yield return null;
        }

        yield return null;
    }
    private IEnumerator ChangeUIFire(float curr, float max)
    {
        float ElapsedTime = 0.0f;

        float percentValue = curr / max;
        while ((ElapsedTime) < 1)
        {
            ElapsedTime += Time.deltaTime * 2;
            LastHealtValure = Mathf.Lerp(LastHealtValure, percentValue, ElapsedTime);
            _lifeBar.fillAmount = (LastHealtValure);
            yield return null;
        }

        yield return null;
    }
    /*
    public void UpdateParryCD(float newPercentaje)
    {
        ParryIndicator.fillAmount = newPercentaje;
    }
    */

}
