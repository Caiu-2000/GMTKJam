
using System.Collections;
using UnityEngine;

public class MapObject : MonoBehaviour, IHittable
{
    private bool CanBeHitted = true;
    [SerializeField] private float anguloInclinacion = 10f; // Ángulo máximo a inclinar
    [SerializeField] private float velocidadRotacion = 25f;  // Qué tan rápido se inclina

    private Quaternion rotacionInicial;
    private Coroutine corrutinaInclinacion; 

    private void Start()
    {

        rotacionInicial = transform.rotation;
    }

    public void Hitt(Hitt hitt)
    {
        if (!CanBeHitted) { return; }
        StartCoroutine(HittCd());
        Incline(hitt);
    }

    private IEnumerator HittCd()
    {
        CanBeHitted = false;
        yield return new WaitForSeconds(0.2f);
        CanBeHitted = true;
    }

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