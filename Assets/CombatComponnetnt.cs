using System.Collections;

using UnityEngine;


[System.Serializable]
public class CombatComponnetnt : MonoBehaviour
{

    [SerializeField] private Tool CurrentWeapon;
    public bool FromPlayer = false;

    private bool CanAttack = true;
    

    #region Debug

    private bool Drawdebug = false;

    #endregion



    public void InitialiceThis( PlayerInput _input)
    {
        _input.OnAttackPressed += Attack;
        FromPlayer = true;
    }

    public void Attack()
    {
        if (!CanAttack) { return; }
        StartCoroutine(AttackCd());
        StartCoroutine(AttackSecuence());

    }


    private IEnumerator AttackSecuence()
    {
        float elapsedtime = 0.0f;
        yield return new WaitForSeconds(0.05f);
        while (true)
        {
            elapsedtime += Time.deltaTime;
            // TODO : CREAR UNA LAYER QUE SEA DE GOLPEABLES Y SOLO HACER PHISICS OVERLAP AHI
            Collider[] collided =  Physics.OverlapBox(transform.position + new Vector3(1, 0, 0), CurrentWeapon.HittboxSize);
            Drawdebug = true;
            foreach (Collider collider in collided) 
            {
                
                if (collider.TryGetComponent<IHittable>( out IHittable hittable))
                {
                    
                    if (FromPlayer && collider.gameObject.GetComponent<Player>() ) continue;
                    print("Hittable" + collider.name);
                    collider.GetComponent<IHittable>().Hitt(new Hitt(CurrentWeapon.damage));
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
        Gizmos.DrawWireCube(AttackPosition(GeneralHandler.MouseWorldPosition), CurrentWeapon.HittboxSize);
    }

    protected Vector3 AttackPosition(Vector3 pointedPos)
    {
        Vector3 position = Vector3.Normalize(pointedPos -transform.position )  * 1.1f + GeneralHandler.player.transform.position;

        return  new Vector3(position.x , 1 , position.z);
    }

}
