using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AnimatorSpriteController : MonoBehaviour
{

    public Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }


}
