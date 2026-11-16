using System.Collections.Generic;
using UnityEngine;

public class AfterImagePool : MonoBehaviour
{
    [SerializeField] private int initialSize = 10;

    private readonly Queue<AfterImageGhost> available = new Queue<AfterImageGhost>();

    private void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            Create();
        }
    }

    public AfterImageGhost Get()
    {
        if (available.Count == 0) Create();
        return available.Dequeue();
    }

    private void Create()
    {
        var go = new GameObject("AfterImageGhost");
        go.transform.SetParent(transform);
        go.AddComponent<SpriteRenderer>();

        var ghost = go.AddComponent<AfterImageGhost>();
        ghost.Finished += Return;

        go.SetActive(false);
        available.Enqueue(ghost);
    }

    // Se llama cuando la copia termino de desvanecerse
    private void Return(AfterImageGhost ghost)
    {
        available.Enqueue(ghost);
    }
}
