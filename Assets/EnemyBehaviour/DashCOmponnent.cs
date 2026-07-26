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

    public delegate void DashedSucces();

    public DashedSucces OnDashed;
    private void Dash()
    {

        if (CanDash) StartCoroutine(DashSecuence());
    }



    public void ActivateDash()
    {
        CanDash = true;
        GeneralHandler.player.input.OnDashPressed += Dash;
        DashLinked = true;
    }
    

    private IEnumerator DashSecuence()
    {
        OnDashed?.Invoke();
        Vector2 DirectionReference = LastWalkedDirection;
        GeneralHandler.player.input.DeactivateActions();
        float AuxiliarSpeed = GeneralHandler.player._movement.Speed;
        float elapsedTime = 0;
        
        CanDash = false;
        while (true)
        {
            elapsedTime += Time.deltaTime;
            GeneralHandler.player.transform.position = Vector3.MoveTowards(GeneralHandler.player.transform.position, GeneralHandler.player.transform.position + new Vector3(DirectionReference.x, 0, DirectionReference.y) * DashStrength, elapsedTime / DashDuration);
            
            
            /*
            GeneralHandler.player._movement.Move(DirectionReference);
            GeneralHandler.player._damCD = true;
            */
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
        
    }
    private void FixedUpdate()
    {
        
    }


    //BORRAAAAAR
    private void Start()
    {
        GeneralHandler.Dash = this;
    }
}
