using Unity.Collections;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
    [SerializeField] private Sprite[] DirSprites;
    [SerializeField] private Sprite[] AttackSprites;

    [SerializeField] private Enemy parent;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        spriteRenderer.sprite = DirSprites[Get4DirectionIndex(parent._movement.LastDirection)];
    }
    public int Get4DirectionIndex(Vector2 dir)
    {
 
        // 1. Obtener ángulo en grados (-180 a 180)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // 2. Normalizar a rango de 0 a 360
        if (angle < 0) angle += 360f;

        // 3. Aplicar offset de 45° y dividir en 4 sectores de 90°
        int index = Mathf.FloorToInt((angle + 45f) / 90f) % 4;

        return index; // 0: Derecha, 1: Arriba, 2: Izquierda, 3: Abajo
    }
}
