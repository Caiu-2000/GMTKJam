using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AnimatorSpriteController : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if ( transform.position.x - GeneralHandler.player.transform.position.x  > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }


}
