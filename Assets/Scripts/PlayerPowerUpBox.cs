using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpBox : MonoBehaviour
{

    // [SerializeField] private PowerUpImage powerImage;

    private PowerUpImage powerImage;

    private int powerNum = 0;
    PlayerController playerController;
    GameHandeler gameHandeler;
    Rigidbody rbShell;
    int speed = 20;
    public Vector3 shellMoveMent = new Vector3(-17, 0, 20);
    public bool aktivShell = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        GameObject gh = GameObject.Find("GameHandeler");
        gameHandeler = gh.GetComponent<GameHandeler>();
        if (playerController.secondPlayer == false)
        {
            GameObject pc = GameObject.Find("PlayerCanvas");
            powerImage = pc.GetComponentInChildren<PowerUpImage>();
        }
        else
        {
            GameObject pc = GameObject.Find("PlayerCanvas Variant");
            powerImage = pc.GetComponentInChildren<PowerUpImage>();
        }
               
    }

    // Update is called once per frame
    void Update()
    {
        // Here Ludvig
        if (playerController.secondPlayer == false)
        {
            if (Input.GetKey("e"))
            {
                usePower();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                usePower();
            }
        }

      
    }

    private void OnTriggerEnter(Collider collidedBox) {
        if (collidedBox.transform.CompareTag("PickUpBox")) {
            // Debug.Log("Power up!");
            collidedBox.GetComponent<PickUpBox>().HidePowerBox();
            randomPowerUp();
        }
    }

    private void randomPowerUp() {
        if (powerNum == 0) {
            powerNum = Random.Range(1, 3);
            powerImage.setPowerImage(powerNum);
        }
    }


    private void usePower() {
        if (powerNum == 1) {
            Debug.Log("SHRROOOOM! + shell");
            //speedShroom();
            useSheel();
            speedShroom();
        }

        else if (powerNum == 2) {
            Debug.Log("Shell.");
            useSheel();
        }

        powerNum = 0;
        powerImage.setPowerImage(powerNum);
    }

    private void speedShroom() {
        //PlayerController player = gameObject.GetComponentInParent<PlayerController>();
        playerController.currentSpeed += 80;
    }

   
    void useSheel()
    {
        aktivShell = true;
        GameObject gs = gameHandeler.greenSheel;
        GameObject sh;

        if (playerController.secondPlayer == false)
        {
            /*
            UnityEngine.Object pPrefab = Resources.Load("Assets/Prefabs/GreenShell");
            GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, gameHandeler.playerSceondPositon);
            pNewObject.transform.position = gameHandeler.playerCartPositon2.position;
            */
            sh = Instantiate(gs, gameHandeler.playerPostiona);
            Vector3 v3 = gameHandeler.playerCartPositon1.position;
           
            v3.x = v3.x - 0.5f;
            v3.y = v3.y + 0.5f;
            sh.transform.position = v3;
           
        }
        else
        {
            sh = Instantiate(gs, gameHandeler.playerSceondPositon);
            Vector3 v3 = gameHandeler.playerCartPositon2.position;
            v3.x = v3.x - 0.5f;
            v3.y = v3.y + 0.5f;
            sh.transform.position = v3;
           
        }
        /*
        Debug.Log(" f�rsta " + sh.transform.rotation);
        float yAxies = Random.Range(50f, 180f);
        //yAxies = yAxies * 10;
        sh.transform.rotation = Quaternion.Euler(new Vector3(0, yAxies, 0));
        Debug.Log("rotation" + sh.transform.rotation);
        Debug.Log(" rotarin of y " + sh.transform.rotation.y);
        */

        rbShell = sh.GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (aktivShell)
        {
            rbShell.velocity = shellMoveMent;
        }
    }



}
