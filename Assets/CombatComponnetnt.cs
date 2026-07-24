using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class CombatComponnetnt : MonoBehaviour
{

    [SerializeField] private Tool CurrentWeapon;
    public bool FromPlayer = false;

    private bool CanAttack = true;
    

    #region Debug

    private bool Drawdebug = false;
    private Vector3 LastAttackedPos;
    #endregion



    public void InitialiceThis( PlayerInput _input)
    {
        _input.OnAttackPressed += Attack;
        FromPlayer = true;
    }
    public void InitialiceThis(StateMachine Machine)
    {
        Machine.OnAttack += Attack;
        print("Se llego bi en a machine");
    }

    public void Attack( Vector3 AttackedGlobalPosition)
    {
        print("Se llamo attack");
        if (!CanAttack) { return; }
        StartCoroutine(AttackCd());
        LastAttackedPos = AttackedGlobalPosition;
        StartCoroutine(AttackSecuence(AttackedGlobalPosition));

    }


    private IEnumerator AttackSecuence(Vector3 AttackedPos)
    {
        print("Ataco  " + AttackedPos + "  " + AttackPosition(AttackedPos));
        float elapsedtime = 0.0f;
        yield return new WaitForSeconds(0.05f);
        while (true)
        {
            elapsedtime += Time.deltaTime;
            // TODO : CREAR UNA LAYER QUE SEA DE GOLPEABLES Y SOLO HACER PHISICS OVERLAP AHI
            Collider[] collided =  Physics.OverlapBox(AttackPosition(AttackedPos), CurrentWeapon.HittboxSize);
            Drawdebug = true;
            foreach (Collider collider in collided) 
            {
                
                if (collider.TryGetComponent<IHittable>( out IHittable hittable))
                {
                    
                    if (FromPlayer && collider.gameObject.GetComponent<Player>() ) continue;
                    if (!FromPlayer && collider.gameObject.GetComponent<Enemy>()) continue;
                    print("COnsegui llegar aca con collider de + " + collider.gameObject.name);
                    ApplyAttack(collider);
                }
            
            }

            if (elapsedtime > 0.05f) break;
            yield return null;
        }
       Drawdebug = false;
    }

    private IEnumerator AttackCd()
    {
        CanAttack = false;
        yield return new WaitForSeconds(0.2f);
        CanAttack = true;
    }

    private void OnDrawGizmos()
    {
        if (!Drawdebug) return;
        Gizmos.DrawWireCube(AttackPosition(LastAttackedPos), CurrentWeapon.HittboxSize);
    }

    protected Vector3 AttackPosition(Vector3 pointedPos)
    {
        Vector3 position = Vector3.Normalize(pointedPos -transform.position )  * 1.1f + transform.position;

        return  new Vector3(position.x , 1 , position.z);
    }


    public void ChangeWeapon(Tool newWeapon)
    {
        CurrentWeapon = newWeapon;
    }
    public void ApplyAttack(Collider hittedObj)
    {
        hittedObj.gameObject.GetComponent<IHittable>().Hitt(new Hitt(CurrentWeapon.damage));
    }
    public void ApplyAttack(Player player)
    {
        player.Hitt(new Hitt(CurrentWeapon.damage));
    }
}
