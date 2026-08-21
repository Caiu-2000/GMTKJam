using System.Collections.Generic;
using UnityEngine;

public class ObjectsHider : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private LayerMask occlusionLayer;
    [SerializeField] private float transparentAlpha = 0.3f;

    private List<Renderer> currentObjects = new List<Renderer>();

    void Update()
    {
        // Restaurar objetos anteriores
        foreach (Renderer rend in currentObjects)
        {
            SetAlpha(rend, 1f);
        }

        currentObjects.Clear();

        // Dirección desde cámara hacia jugador
        Vector3 direction = player.position - Camera.main.transform.position;
        float distance = direction.magnitude;

        RaycastHit[] hits = Physics.RaycastAll(
            Camera.main.transform.position,
            direction.normalized,
            distance,
            occlusionLayer
        );

        foreach (RaycastHit hit in hits)
        {
            Renderer rend = hit.collider.GetComponent<Renderer>();
            print(hit);
            if (rend != null && !currentObjects.Contains(rend))
            {
                currentObjects.Add(rend);
                SetAlpha(rend, transparentAlpha);
            }
        }
    }

    private void SetAlpha(Renderer rend, float alpha)
    {
        foreach (Material mat in rend.materials)
        {
            Color color = mat.color;
            color.a = alpha;
            mat.color = color;
        }
    }
}
