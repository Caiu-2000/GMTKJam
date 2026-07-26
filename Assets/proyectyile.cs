using UnityEngine;

public class proyectyile : MonoBehaviour
{

    Vector3 moveDir;
    [SerializeField]
    private float Speed = 3.0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void ResetBullet(Vector3 newPos , Vector3 NewDir)
    {
        transform.position = newPos;
        moveDir = NewDir;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDir * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.Hitt(new Hitt(5,this.transform.position));
            transform.position = new Vector3(0,50,0);
        }
    }

}
