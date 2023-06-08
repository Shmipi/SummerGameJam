using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
{

   
 
    Collider colliderShell;
    int wallCounter = 0;

    PlayerPowerUpBox pw;
    GameObject pa;

    // Start is called before the first frame update
    void Start()
    {

        pa = gameObject.transform.parent.gameObject;
        pw = pa.GetComponentInChildren<PlayerPowerUpBox>();
        colliderShell = gameObject.GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            wallCounter++;
            if(wallCounter == 1) {
                pw.shellMoveMent = new Vector3(17, 0, 20);
            }
            if(wallCounter == 2)
            {
                pw.shellMoveMent = new Vector3(-17, 0, 20);
            }
            if (wallCounter == 3)
            {
                pw.shellMoveMent = new Vector3(17, 0, 20);
            }
            if (wallCounter == 4)
            {
                pw.aktivShell = false;
                Destroy(gameObject);
                
            }

        }
        if (collision.transform.CompareTag("Player"))
        {
            /*
            pw.aktivShell = false;
            Destroy(gameObject);
            StartCoroutine(playerStopp());
            */

        }
        Debug.Log(collision.transform.tag);
        //Debug.Log("Col");
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        //Debug.Log(other.tag);
        /*
        if (other.transform.CompareTag("PickUpBox"))
        {
            // Debug.Log("Power up!");
            collidedBox.GetComponent<PickUpBox>().HidePowerBox();
            randomPowerUp();
        }
        
        //Debug.Log("träffade något");
       
    }
*/
    IEnumerator playerStopp()
    {
        Debug.Log("är i courentinr");
        PlayerController pc = pa.GetComponent<PlayerController>();
        float ogMax = pc.maxSpeed;
        pc.maxSpeed = 0;
        yield return new WaitForSeconds(2);
        pc.maxSpeed = ogMax;
        yield break;

    }
}