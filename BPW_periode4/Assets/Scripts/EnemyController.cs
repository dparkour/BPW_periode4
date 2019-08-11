using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody myRB;
    public float moveSpeed;

    public PlayerController thePlayer;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();

    }

    private void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, thePlayer.transform.position) > 3f)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        var dir = thePlayer.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

}
