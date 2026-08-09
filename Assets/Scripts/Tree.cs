using System.Collections;
using UnityEngine;

public class Tree : MonoBehaviour, IHittable
{
    [SerializeField] float life = 3;
    [SerializeField] int woodToGive = 1;
    bool vulnerable = false;

    //Estas son las variables para la logica de que se incline al golpearlo
   private float anguloInclinacion = 10f; // Ángulo máximo a inclinar
   private float velocidadRotacion = 35f;  // Qué tan rápido se inclina

    private Quaternion rotacionInicial;
    private Coroutine corrutinaInclinacion;

    private void Start()
    {

        rotacionInicial = transform.rotation;
    }


    public void Hitt(Hitt hitt)
    {
        
        if (!vulnerable)
        {
            SoundManager.instance.PlayRandom(SoundTypes.Tree);
            life -= hitt.HittDamage;
            vulnerable = true;
            StartCoroutine(IFrame());
            Incline(hitt); // Esta funcion da el feedback
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

    // Esto lo hice con bastante ia no lo voy a negar
    private void Incline(Hitt hittdata)
    {
        Vector3 direccionGolpe = (transform.position - hittdata.AttackFrom).normalized;
        direccionGolpe.y = 0;

        if (direccionGolpe != Vector3.zero)
        {
            Vector3 ejeRotacion = Vector3.Cross(Vector3.up, direccionGolpe);


            Quaternion rotacionObjetivo = Quaternion.AngleAxis(anguloInclinacion, ejeRotacion) * rotacionInicial;

            if (corrutinaInclinacion != null)
            {
                StopCoroutine(corrutinaInclinacion);
            }

            corrutinaInclinacion = StartCoroutine(InclinarObjeto(rotacionObjetivo));
        }
    }

    private IEnumerator InclinarObjeto(Quaternion destino)
    {

        while (Quaternion.Angle(transform.rotation, destino) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, destino, Time.deltaTime * velocidadRotacion);
            yield return null;
        }
        transform.rotation = destino;


        while (Quaternion.Angle(transform.rotation, rotacionInicial) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionInicial, Time.deltaTime * velocidadRotacion);
            yield return null;
        }

        transform.rotation = rotacionInicial;
        corrutinaInclinacion = null;
    }

}
