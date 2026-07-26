using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeathState : DeathState
{
    public override void StartState()
    {
        ParentMachine._movement.Move(new Vector2(0, 0));
        StartCoroutine(DiadSecuence());
    }

    private IEnumerator DiadSecuence()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(2);
    }
}
