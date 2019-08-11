using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractise : MonoBehaviour
{
    public OpenGate openGate;

    public GameObject ParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        openGate = FindObjectOfType<OpenGate>();
        openGate.targets.Add(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //Instantiate(ParticleEffect, transform.position, Quaternion.identity);
            ParticleEffect.SetActive(true);
            openGate.targets.Remove(this.gameObject);
        }
    }
}
