using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public int damageToGive;

    public float HitCD = 1;

    bool canHit = true;
    
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && canHit)
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            StartCoroutine(HitCooldown());
        }
    }

    IEnumerator HitCooldown()
    {
        canHit = false;
        yield return new WaitForSeconds(HitCD);
        canHit = true;
    }
}
