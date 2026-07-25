using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Rendering;


public class DashCOmponnent : MonoBehaviour
{
    public  bool CanDash = false;

    private Vector2 LastWalkedDirection;
    [SerializeField] float DashStrength = 10;
    [SerializeField] float DashDuration = 0.25f;

    public bool DashLinked = false;
 
    private void Dash()
    {
        print("SE llamo dash");
        if (CanDash) StartCoroutine(DashSecuence());
    }



    public void ActivateDash()
    {
        CanDash = true;
        GeneralHandler.player.input.OnDashPressed += Dash;
    }
    

    private IEnumerator DashSecuence()
    {
        Vector2 DirectionReference = LastWalkedDirection;
        GeneralHandler.player.input.DeactivateActions();
        float AuxiliarSpeed = GeneralHandler.player._movement.Speed;
        float elapsedTime = 0;
        GeneralHandler.player._movement.Speed = DashStrength;
        CanDash = false;
        while (true)
        {
            elapsedTime += Time.deltaTime;
            
            GeneralHandler.player._movement.Move(DirectionReference);
            GeneralHandler.player._damCD = true;
            if (elapsedTime > DashDuration) break;
            yield return null;

        }

        GeneralHandler.player._damCD = false;
        GeneralHandler.player._movement.Speed = AuxiliarSpeed;
        GeneralHandler.player.input.ActivateActions();
        yield return new WaitForSeconds(1.0f);
        CanDash = true;



    }

    private void Update()
    {
        Vector2 auxiliar = LastWalkedDirection;
        LastWalkedDirection = GeneralHandler.player.input.GetMoveDir();
        if (LastWalkedDirection ==  Vector2.zero ) { LastWalkedDirection = auxiliar; }
        if (!DashLinked) { 
            GeneralHandler.Dash = this;
            GeneralHandler.player.input.OnDashPressed += Dash;
            DashLinked = true;
        }
    }
    private void FixedUpdate()
    {
        
    }


    //BORRAAAAAR
    private void Start()
    {
        CanDash = true;
    }
}
