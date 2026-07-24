using System.Collections;
using UnityEngine;

public class Tree : MonoBehaviour, IHittable
{
    [SerializeField] float life = 3;
    [SerializeField] int woodToGive = 1;
    bool vulnerable = false;
    public void Hitt(Hitt hitt)
    {
        if (!vulnerable)
        {
            life -= hitt.HittDamage;
            vulnerable = true;
            StartCoroutine(IFrame());
        }
    }
    void Update()
    {
        if (life <= 0)
        {
            Player player = GeneralHandler.Instance.GetPlayer();
            player.inventory.AddLogs(woodToGive);
            Destroy(gameObject);
        }
    }
    IEnumerator IFrame()
    {
        yield return new WaitForSeconds(0.2f);
        vulnerable = false;
    }
}
