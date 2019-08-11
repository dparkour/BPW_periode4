using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBarrel : MonoBehaviour
{
    Animator animator;
    public float PowerTime;
    AudioSource audioSource;
    public GameObject ParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.GetChild(0).GetComponent<GunController>().PowerUp(PowerTime);
            Instantiate(ParticleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
