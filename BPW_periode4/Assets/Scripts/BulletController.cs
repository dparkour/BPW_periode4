using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;
    public GameObject ParticleEffect;

    public float lifeTime;

    public int damageToGive;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.transform.parent.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        
        }


        GameObject Effect = Instantiate(ParticleEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
