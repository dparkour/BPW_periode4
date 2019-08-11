using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(targets.Count == 0)
        {
            Anim.SetBool("GateOpen", true);
        }
    }

}
