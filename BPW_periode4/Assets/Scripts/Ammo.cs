using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    GunController gunController;
    public int AmmoGiven;
    // Start is called before the first frame update
    void Start()
    {
        gunController = GunController.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gunController.Ammo += AmmoGiven;
            Destroy(transform.parent.gameObject);
        }
    }


}
