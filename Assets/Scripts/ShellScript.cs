using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
{

    Rigidbody rbShell;
    int shellSpeed = 5;
    bool shellsUses = false;
    Collider colliderShell;

    // Start is called before the first frame update
    void Start()
    {

        rbShell = gameObject.GetComponent<Rigidbody>();
        colliderShell = gameObject.GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (shellsUses)
        {
            rbShell.velocity = new Vector3(-2, 0, 20);

        }

    }
}
