using System.Collections;
using UnityEngine;

public class BulletHellBehaviour : MonoBehaviour
{
    [SerializeField] private proyectyile bullets;
    private int NumberOfBullets = 20;

    private proyectyile[] proyectiles;

    void Start()
    {
        proyectiles = new proyectyile[NumberOfBullets * 3];
        for (int i = 0; i < NumberOfBullets * 3; i++)
        {

            proyectiles[i] = Instantiate(bullets);
            Vector3 direction = Quaternion.Euler(0f, 18 * i, 0f) * Vector3.forward;
            proyectiles[i].ResetBullet(new Vector3(0, 50, 0), direction);
        }
        StartCoroutine(RotateWaves());
    }


    public void SendWave(int group = 0)
    {
        if ( group == 3)
        {
            group = 2;
        }
        for (int i = group * 10; i < NumberOfBullets *( group +1); i++)
        {
            Vector3 direction = Quaternion.Euler(0f, 18 * i, 0f) * Vector3.forward;
            proyectiles[i].ResetBullet(this.transform.position, direction);

        }
    }

    private IEnumerator RotateWaves()
    {
        int wave = 0;
        while (true)
        {
            SendWave(wave);
            print("SE envio Wave  " + wave);
            yield return new WaitForSeconds(3);
            wave++;
            if (wave >= 3)
            {
                wave = 0;
            }
        }

    }
}
