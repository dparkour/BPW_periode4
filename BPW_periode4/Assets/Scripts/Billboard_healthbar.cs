using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard_healthbar : MonoBehaviour
{

    public Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
    }
}
