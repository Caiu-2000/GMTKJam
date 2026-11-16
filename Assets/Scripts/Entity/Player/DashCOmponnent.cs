using System.Collections;

using UnityEngine;



public class DashCOmponnent : MonoBehaviour
{
    [SerializeField] float DashCooldown = 1.0f;
    public event System.Action<float> OnCooldownStarted;
    public event System.Action OnReady;
    public event System.Action OnDashFinished;
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
        OnReady?.Invoke();
    }
    

    private IEnumerator DashSecuence()
    {
        OnDashed?.Invoke();
        OnCooldownStarted?.Invoke(DashDuration+DashCooldown);
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
        OnDashFinished?.Invoke();
        GeneralHandler.player._damCD = false;
        GeneralHandler.player._movement.Speed = AuxiliarSpeed;
        GeneralHandler.player.input.ActivateActions();
        yield return new WaitForSeconds(DashCooldown);
        CanDash = true;
        OnReady?.Invoke();


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
