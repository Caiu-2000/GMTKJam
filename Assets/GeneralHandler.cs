using UnityEngine;

public class GeneralHandler : MonoBehaviour
{


    
    public static GeneralHandler Instance { get; private set; }
    public static Vector3 MouseWorldPosition;
    public static Player player;
    public static campfireFlicker Campfire;
    public static UiHandler UiHandler;
    public IsPlayerOnTheLight lightChecker;
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
        //TODO: player.turnDashOn();
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
