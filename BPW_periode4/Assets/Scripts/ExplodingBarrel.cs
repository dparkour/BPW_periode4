using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
    Animator animator;
    public float ExplosionTime;
    public GameObject ParticleEffect;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            InstantExplosion();
        }
        if (other.tag == "Ground")
        {
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        audioSource.Play();
        animator.SetBool("Exploding", true);
        yield return new WaitForSeconds(ExplosionTime);
        Instantiate(ParticleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void InstantExplosion()
    {
        Instantiate(ParticleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
