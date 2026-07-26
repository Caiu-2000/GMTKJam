using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataTransferrer : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Animator animator;
    [SerializeField] CombatComponnetnt combat;
    SpriteRenderer spirte;

    private void Start()
    {
        print(player);
        player.OnEntityAttacked += Attacked;
        player.OnDamaged += Damaged;
        player.GetComponent<DashCOmponnent>().OnDashed += Dashed;
        
        spirte = GetComponent<SpriteRenderer>(); 
    }

    private void Dashed()
    {
        print("dasheo");
        animator.SetTrigger("Dashed");
    }

    private void Update()
    {
        animator.SetBool("Moving" , player._movement._RB.linearVelocity != Vector3.zero);
        print( player._movement._RB.linearVelocity != Vector3.zero);
        print(Mouse.current.position);
        spirte.flipX = IsMouseOnRightSide();
    }
    private void Attacked()
    {
        animator.SetTrigger("attacked");
    }
    private void Damaged(Hitt golpe)
    {
        animator.SetTrigger("damaged");
    }
    public bool IsMouseOnRightSide()
    {
        // Verificación de seguridad por si no hay mouse conectado
        if (Mouse.current == null) return false;

        // Lee la posición X actual del cursor en píxeles
        float mouseX = Mouse.current.position.ReadValue().x;

        // Calcula el punto medio de la pantalla
        float screenCenter = Screen.width / 2f;

        // Devuelve true si la X del mouse es mayor a la mitad de la pantalla
        return mouseX > screenCenter;
    }
}
