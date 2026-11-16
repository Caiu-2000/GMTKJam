using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AfterImageGhost : MonoBehaviour
{
    // Nombres de referencia (Reference) de las propiedades en Shader Graph.
    // Deben coincidir EXACTO con lo que figura en el Blackboard.
    private static readonly int MainTexId = Shader.PropertyToID("_MainTex");
    private static readonly int OpacityId = Shader.PropertyToID("_Opacity");
    private static readonly int InnerLinesId = Shader.PropertyToID("_ControlInnerLines");
    private static readonly int SpriteRectId = Shader.PropertyToID("_SpriteRect");

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer source;
    private MaterialPropertyBlock block;
    private Coroutine fadeRoutine;

    private float opacity;
    private float innerLines;

    public event Action<AfterImageGhost> Finished;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        block = new MaterialPropertyBlock();
    }

    public void Setup(SpriteRenderer sourceSprite, Material ghostMaterial, float lifetime,
                      float startOpacity, float innerLinesValue)
    {
        source = sourceSprite;
        opacity = startOpacity;
        innerLines = innerLinesValue;

        transform.position = source.transform.position;
        transform.rotation = source.transform.rotation;
        transform.localScale = source.transform.lossyScale;

        spriteRenderer.sharedMaterial = ghostMaterial;
        spriteRenderer.sortingLayerID = source.sortingLayerID;
        spriteRenderer.sortingOrder = source.sortingOrder - 1;
        spriteRenderer.flipX = source.flipX;
        spriteRenderer.flipY = source.flipY;

        ApplyProperties();
        gameObject.SetActive(true);

        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(Fade(lifetime, startOpacity));
    }

    // La copia queda congelada en el frame que tenia el sprite original
    // al momento de aparecer. No se actualiza despues: es una foto.
    private void ApplyProperties()
    {
        Sprite sprite = source.sprite;
        spriteRenderer.sprite = sprite;

        spriteRenderer.GetPropertyBlock(block);

        if (sprite != null)
        {
            Texture2D tex = sprite.texture;
            block.SetTexture(MainTexId, tex);

            // Rectangulo del frame dentro del spritesheet, normalizado (0 a 1).
            // x, y = inicio del frame. z, w = tamano del frame.
            Rect r = sprite.textureRect;
            Vector4 uvRect = new Vector4(
                r.x / tex.width,
                r.y / tex.height,
                r.width / tex.width,
                r.height / tex.height
            );
            block.SetVector(SpriteRectId, uvRect);
        }

        block.SetFloat(OpacityId, opacity);
        block.SetFloat(InnerLinesId, innerLines);

        spriteRenderer.SetPropertyBlock(block);
    }

    private IEnumerator Fade(float lifetime, float startOpacity)
    {
        float elapsed = 0f;
        while (elapsed < lifetime)
        {
            elapsed += Time.deltaTime;
            opacity = Mathf.Lerp(startOpacity, 0f, elapsed / lifetime);

            spriteRenderer.GetPropertyBlock(block);
            block.SetFloat(OpacityId, opacity);
            spriteRenderer.SetPropertyBlock(block);

            yield return null;
        }

        source = null;
        gameObject.SetActive(false);
        Finished?.Invoke(this);
    }
}
