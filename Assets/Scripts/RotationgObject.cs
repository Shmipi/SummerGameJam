using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationgObject : MonoBehaviour
{
    public float rotationSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
       
                    transform.Rotate(
                    Vector3.right * rotationSpeed * Time.deltaTime +
                    Vector3.up * rotationSpeed * Time.deltaTime +
                    Vector3.forward * rotationSpeed * Time.deltaTime,
                    Space.Self
                    ); 
        
    }
}
