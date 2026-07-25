using UnityEngine;

public class GeneralHandler : MonoBehaviour
{


    
    public static GeneralHandler Instance { get; private set; }
    public static Vector3 MouseWorldPosition;
    public static Player player;
    public static campfireFlicker Campfire;
    public static UiHandler UiHandler;
    public static DashCOmponnent Dash;
    public IsPlayerOnTheLight lightChecker;

    public static bool DamageBuffed = false;

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
        //TODO: player.ImproveBasics();
    }
    public void TurnOnReneration()
    {
        //TODO: player.TurnOnReneration();
    }
    public IsPlayerOnTheLight GetLightManager()
        { return lightChecker; }
}
