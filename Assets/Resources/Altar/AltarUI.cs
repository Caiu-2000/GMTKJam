using UnityEngine;
using UnityEngine.InputSystem;

public class AltarUI : MonoBehaviour
{
    Player player;
    int nextUpgrade = 0;
    int maxUpgrade = 3;

    // Update is called once per frame
    void Update()
    {
        if (player == null) player = GeneralHandler.Instance.GetPlayer();
        if (Keyboard.current.tKey.wasPressedThisFrame && nextUpgrade < maxUpgrade)
        {
            if (nextUpgrade == 0) GeneralHandler.Instance.TurnDashOn();
            else if (nextUpgrade == 1) GeneralHandler.Instance.ImprovedBasics();
            else if (nextUpgrade == 2) GeneralHandler.Instance.TurnOnReneration();
            nextUpgrade++;
            gameObject.SetActive(false);
        }
    }
}
