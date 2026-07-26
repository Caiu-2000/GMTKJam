using UnityEngine;
using UnityEngine.InputSystem;

public class GeneralHandler : MonoBehaviour
{


    
    public static GeneralHandler Instance { get; private set; }
    public static Vector3 MouseWorldPosition;
    public static Player player;
    public static campfireFlicker Campfire;
    public static UiHandler UiHandler;
    public static DashCOmponnent Dash;
    public IsPlayerOnTheLight lightChecker;

    public static HealBuff Heatlbuff;

    public static bool DamageBuffed = false;
    public static DamageUpgrade DamageBuff;

    private void Awake()
    {
     
        if (Instance != null && Instance != this)
        {
    
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    public Player GetPlayer()
        { return player; }
    public void AddLightAreaChecker(IsPlayerOnTheLight script)
    {
        lightChecker = script;
    }
    public void TurnDashOn()
    {
        Dash.ActivateDash();
    }
    public void ImprovedBasics()
    {
        DamageBuff.Unlock();
    }
    public void TurnOnReneration()
    {
        Heatlbuff.Unlock();
    }
    public IsPlayerOnTheLight GetLightManager()
        { return lightChecker; }


    private void Update()
    {
#if UNITY_EDITOR
        // Detecta las teclas del teclado numérico (Numpad) o los números del teclado principal
        if (Keyboard.current.numpad4Key.wasPressedThisFrame)
            {
            print("Dash");
                TurnDashOn();
            }
            else if (Keyboard.current.numpad5Key.wasPressedThisFrame)
            {
            print("Dam");
            ImprovedBasics();
            }
            else if (Keyboard.current.numpad6Key.wasPressedThisFrame)
            {
            print("Regen");
            TurnOnReneration();
            }
#endif
    }


}
