using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public int Damage = 4;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealthManager>().HurtPlayer(Damage /2);
        }
        if(other.tag == "Enemy")
        {
            other.transform.parent.GetComponent<EnemyHealthManager>().HurtEnemy(Mathf.RoundToInt(Damage/2));
        }
    }
}
