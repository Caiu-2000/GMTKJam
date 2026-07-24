using UnityEngine;

public class PatrollState : State
{
    private Vector3 ObjPosition;
    private Vector3 FirstPos;
    private float Range = 5.0f;

    [SerializeField] 
    private float DetectionRange = 10.0f;


    private float OldSpeed;

    public override void StartState()
    {
        FirstPos = transform.position;
        OldSpeed = ParentMachine._movement.Speed;
        ParentMachine._movement.Speed = 2;

        NewPos();
    }
    public override void StopState()
    {
        ParentMachine._movement.Speed = OldSpeed;
    }
    public override void UpdateState()
    {
        if (Vector3.Distance(transform.position, ObjPosition) <= 0.2f)
        {
            NewPos();
        }
        else if ((Vector3.Distance(transform.position, GeneralHandler.player.transform.position) <= DetectionRange)){
            ParentMachine.ChangeState(DefaultNextState);
        }
        else
        {
            ParentMachine._movement.Move(ParentMachine._ai.DirectionTowards(ObjPosition));
        }
        
    }


    private void NewPos()
    {
        ObjPosition = FirstPos + new Vector3(Random.Range(-Range, Range),0,Random.Range(-Range, Range));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(ObjPosition, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);


    }
}
