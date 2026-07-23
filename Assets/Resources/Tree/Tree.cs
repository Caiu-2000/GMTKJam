using System.Collections;
using UnityEngine;

public class Tree : MonoBehaviour, IHittable
{
    [SerializeField] int life = 3;
    bool vulnerable = false;
    public void Hitt(Hitt hitt)
    {
        if (!vulnerable)
        {
            life -= 1;
            vulnerable = true;
            StartCoroutine(IFrame());
        }
    }
    void Update()
    {
        if (life <= 0)
        {
            Player player = GeneralHandler.Instance.GetPlayer();
            player.inventory.AddLogs(1);
            Destroy(gameObject);
        }
    }
    IEnumerator IFrame()
    {
        yield return new WaitForSeconds(0.2f);
        vulnerable = false;
    }
}
