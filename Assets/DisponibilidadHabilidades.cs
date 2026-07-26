using UnityEngine;
using UnityEngine.UI;

public class DisponibilidadHabilidades : MonoBehaviour
{
    [SerializeField] private Image[] images;
    
    public void ShowHide(int indx,bool hidden = true)
    {
        float filled = 1;

        if (hidden) filled = 0;
        images[indx].fillAmount = filled ;
    }

    private void Update()
    {
        ShowHide(0, GeneralHandler.Dash.CanDash);
        ShowHide(1, GeneralHandler.DamageBuff.IsReady);
        ShowHide(2, GeneralHandler.Heatlbuff.IsReady);
    }
}
