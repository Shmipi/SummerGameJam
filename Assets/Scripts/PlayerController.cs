using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    //movement
    public float currentSpeed;
    public float maxSpeed;
    public float boostSpeed;
    private float realSpeed;

    //steering
    private float steerDirection;
    private float driftTime = 0;
    private float boostTime = 0;

    bool driftLeft = false;
    bool driftRight = false;
    float outwardsDriftForce;

    private bool isSliding;

    private bool touchingGround;

    public bool secondPlayer = false;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        move();
        steer();
        groundNormalRotation();
        drift();
        boosts();
    }
    
    private void move(){
        realSpeed = transform.InverseTransformDirection(rb.velocity).z;

        if (!secondPlayer)
        {
            if (Input.GetKey(KeyCode.W))
            {
                currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime * 0.5f);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                currentSpeed = Mathf.Lerp(currentSpeed, -maxSpeed / 1.75f, 1f * Time.deltaTime);
            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * 1.5f);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime * 0.5f);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                currentSpeed = Mathf.Lerp(currentSpeed, -maxSpeed / 1.75f, 1f * Time.deltaTime);
            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * 1.5f);
            }
        }
       

        Vector3 vel = transform.forward * currentSpeed;
        vel.y = rb.velocity.y;
        rb.velocity = vel;
    }

    private void steer(){
        steerDirection = Input.GetAxisRaw("Horizontal");
        Vector3 steerDirVect;

        float steerAmount;

        if(driftLeft && !driftRight){
            steerDirection = Input.GetAxis("Horizontal") < 0 ? -1.5f : -0.5f;
            transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, Quaternion.Euler(0, -20f, 0), 8f * Time.deltaTime);

            if(isSliding && touchingGround){
                rb.AddForce(transform.right * outwardsDriftForce * Time.deltaTime, ForceMode.Acceleration);
            }
        } else if(driftRight && !driftLeft){
            steerDirection = Input.GetAxis("Horizontal") > 0 ? 1.5f : 0.5f;
            transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, Quaternion.Euler(0, 20f, 0), 8f * Time.deltaTime);

            if(isSliding && touchingGround){
                rb.AddForce(transform.right * -outwardsDriftForce * Time.deltaTime, ForceMode.Acceleration);
            }
        } else {
            transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, Quaternion.Euler(0, 0f, 0), 8f * Time.deltaTime);
        }

        steerAmount = realSpeed > 30 ? realSpeed / 4 * steerDirection : steerAmount = realSpeed / 1.5f * steerDirection;

        steerDirVect = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + steerAmount, transform.eulerAngles.z);

        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, steerDirVect, 3 * Time.deltaTime);
    }

    private void groundNormalRotation(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit, 0.75f)){
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up * 2, hit.normal) *transform.rotation, 7.5f * Time.deltaTime);
            touchingGround = true;
        } else {
            touchingGround = false;
        }
    }

    private void drift(){
        if (secondPlayer!)
        {
            if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
            {
                //transform.GetChild(0).GetComponent<Animator>().SetTrigger("Hop");
                if (steerDirection > 0)
                {
                    driftRight = true;
                    driftLeft = false;
                    Debug.Log("Drifting Right");
                }
                else if (steerDirection < 0)
                {
                    driftRight = false;
                    driftLeft = true;
                    Debug.Log("Drifting Left");
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && touchingGround && currentSpeed > 40 && Input.GetAxis("Horizontal") != 0)
            {
                driftTime += Time.deltaTime;

                //spawn particles
            }

            if (!Input.GetKeyDown(KeyCode.Space) || currentSpeed < 40)
            {
                driftLeft = false;
                driftRight = false;
                isSliding = false;

                //give boost
                if (driftTime > 1.5 && driftTime < 4)
                {
                    boostTime = 0.75f;
                }
                if (driftTime >= 4 && driftTime < 7)
                {
                    boostTime = 1.5f;
                }
                if (driftTime >= 7)
                {
                    boostTime = 2.5f;
                }
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightControl) && touchingGround)
            {
                //transform.GetChild(0).GetComponent<Animator>().SetTrigger("Hop");
                if (steerDirection > 0)
                {
                    driftRight = true;
                    driftLeft = false;
                    Debug.Log("Drifting Right");
                }
                else if (steerDirection < 0)
                {
                    driftRight = false;
                    driftLeft = true;
                    Debug.Log("Drifting Left");
                }
            }

            if (Input.GetKeyDown(KeyCode.RightControl) && touchingGround && currentSpeed > 40 && Input.GetAxis("Horizontal") != 0)
            {
                driftTime += Time.deltaTime;

                //spawn particles
            }

            if (!Input.GetKeyDown(KeyCode.RightControl) || currentSpeed < 40)
            {
                driftLeft = false;
                driftRight = false;
                isSliding = false;

                //give boost
                if (driftTime > 1.5 && driftTime < 4)
                {
                    boostTime = 0.75f;
                }
                if (driftTime >= 4 && driftTime < 7)
                {
                    boostTime = 1.5f;
                }
                if (driftTime >= 7)
                {
                    boostTime = 2.5f;
                }
            }
        }
    }

    private void boosts(){
        boostTime -= Time.deltaTime;
        if(boostTime > 0){
            //call particle systems

            maxSpeed = boostSpeed;
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, 1 * Time.deltaTime);

            Debug.Log("Zoomin!");
        } else{
            //stop particles

            maxSpeed = boostSpeed - 20;
        }
    }
}
