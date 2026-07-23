using UnityEngine;

public class GeneralHandler : MonoBehaviour
{


    
    public static GeneralHandler Instance { get; private set; }
    public static Vector3 MouseWorldPosition;
    public static Player player;
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
}
