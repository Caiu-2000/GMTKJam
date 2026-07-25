using UnityEngine;
using UnityEngine.SceneManagement;

public class GM
{
    public static float HittedColorTime = 0.1f;
    public static Vector2 OppositeDirection(Vector3 from, Vector3 to)
    {
        Vector3 direction = Vector3.Normalize(to - from);
        return new Vector2(direction.x,direction.z);
    }


    public static void PlayerDied()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
}
