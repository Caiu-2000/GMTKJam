using System.Collections;
using UnityEngine;


public class DamageFeedback : MonoBehaviour
{
    private SpriteRenderer _spriteRend;
    [SerializeField] private Entity _entity;

    private void Start()
    {
        _entity.OnDamaged += Damaged;
        _spriteRend = GetComponent<SpriteRenderer>();
    }


    private void Damaged(Hitt data)
    {
        StartCoroutine(PaintRed());
    }

    private IEnumerator PaintRed()
    {
        _spriteRend.color = Color.red;
        yield return new WaitForSeconds(GM.HittedColorTime);
        _spriteRend.color = Color.white;
    }


}
