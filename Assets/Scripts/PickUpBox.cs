using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 5;

    [SerializeField] private Vector3 rotationDirection = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        transform.Rotate(rotateSpeed * rotationDirection * Time.fixedDeltaTime);
    }

}
