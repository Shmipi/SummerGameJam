using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    //movement
    private float currentSpeed;
    public float maxSpeed;
    public float boostSpeed;
    private float realSpeed;

    //steering
    private float steerDirection;
    private float driftTime;

    bool driftLeft = false;
    bool driftRight = false;
    float outwardsDriftForce;

    private bool touchingGround;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        move();
        steer();
        groundNormalRotation();
    }
    
    private void move(){
        realSpeed = transform.InverseTransformDirection(rb.velocity).z;

        if(Input.GetKey(KeyCode.W)){
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime *0.5f);
        } else if(Input.GetKey(KeyCode.S)){
            currentSpeed = Mathf.Lerp(currentSpeed, -maxSpeed / 1.75f, 1f * Time.deltaTime);
        } else {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * 1.5f);
        }

        Vector3 vel = transform.forward * currentSpeed;
        vel.y = rb.velocity.y;
        rb.velocity = vel;
    }

    private void steer(){
        steerDirection = Input.GetAxisRaw("Horizontal");
        Vector3 steerDirVect;

        float steerAmount;

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
        if(Input.GetKeyDown(KeyCode.Space) && touchingGround){
            //transform.GetChild(0).GetComponent<Animator>().SetTrigger("Hop");
            if(steerDirection > 0){
                driftRight = true;
                driftLeft = false;
            } else if (steerDirection < 0){
                driftRight = false;
                driftLeft = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) && touchingGround && currentSpeed > 40 && Input.GetAxis("Horizontal") != 0){
            driftTime += Time.deltaTime;

            //spawn particles
        }

        if(!Input.GetKeyDown(KeyCode.Space) || currentSpeed < 40){
            
        }
    }
}
