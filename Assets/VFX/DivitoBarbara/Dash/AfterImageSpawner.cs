using System.Collections;
using UnityEngine;

public class AfterImageSpawner : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private SpriteRenderer sourceSprite;
    [SerializeField] private AfterImagePool pool;

    [Header("Materiales (crear desde tus Shader Graph)")]
    [SerializeField] private Material ghostMaterial;   // Shader del afterimage
    [SerializeField] private Material outlineMaterial; // Opcional: shader del outline

    [Header("Copias")]
    [SerializeField] private int ghostCount = 5;          // Cantidad de copias por dash
    [SerializeField] private float dashDuration = 0.2f;   // Debe coincidir con DashController
    [SerializeField] private float fadeTime = 0.35f;      // Cuanto tarda cada copia en desvanecerse

    [Header("Propiedades del shader afterimage")]
    [Range(0f, 1f)]
    [SerializeField] private float opacity = 0.7f;           // _Opacity inicial
    [SerializeField] private float controlInnerLines = 1f;   // _ControlInnerLines

    private Coroutine spawnRoutine;
    private Material originalMaterial;

    private void Awake()
    {
        originalMaterial = sourceSprite.sharedMaterial;
    }

    public void BeginSpawning()
    {
        if (spawnRoutine != null) StopCoroutine(spawnRoutine);
        spawnRoutine = StartCoroutine(SpawnLoop());

        // El outline se aplica al sprite real mientras dura el dash
        if (outlineMaterial != null) sourceSprite.material = outlineMaterial;
    }

    public void EndSpawning()
    {
        if (spawnRoutine != null) StopCoroutine(spawnRoutine);
        spawnRoutine = null;

        sourceSprite.sharedMaterial = originalMaterial;
    }

    private IEnumerator SpawnLoop()
    {
        // Reparte las copias de forma pareja durante el dash:
        // la primera sale al inicio y la ultima justo antes de terminar.
        float interval = ghostCount > 1 ? dashDuration / (ghostCount - 1) : dashDuration;
        var wait = new WaitForSeconds(interval);

        for (int i = 0; i < ghostCount; i++)
        {
            var ghost = pool.Get();
            ghost.Setup(sourceSprite, ghostMaterial, fadeTime, opacity, controlInnerLines);

            if (i < ghostCount - 1) yield return wait;
        }

        spawnRoutine = null;
    }
}
